using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Enumeration;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.BA;
using Kiss.Model.DTO.Wsh;
using Kiss.BL.Kbu;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Key für Dictionary.
    /// Zu einem Valutadatum und zu einem Empfänger soll nur ein Beleg erzeugt werden.
    /// </summary>
    public class BelegKey
    {
        #region Properties

        public int? BaZahlungswegID
        {
            get;
            set;
        }

        public DateTime ValutaDatum
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool Equals(object obj)
        {
            if (!(obj is BelegKey))
            {
                return false;
            }
            BelegKey other = (BelegKey)obj;
            if (BaZahlungswegID == other.BaZahlungswegID
               && ValutaDatum == other.ValutaDatum)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int result = ValutaDatum.GetHashCode();
            if (BaZahlungswegID.HasValue)
            {
                result = result * 7 + BaZahlungswegID.Value;
            }
            return result;
        }

        #endregion

        #endregion
    }

    /// <summary>
    /// Service um einen Auszahlvorschalg zu handeln
    /// </summary>
    public class WshAuszahlvorschlagService : ServiceBase
    {
        #region Constructors

        private WshAuszahlvorschlagService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Lade die <paramref name="offenePositionen"/> und <paramref name="belege"/> für die gegebene <paramref name="faLeistungId"/>.
        /// Es werden auch freigegebene Belege berücksichtigt.
        /// </summary>
        /// <param name="unitOfWork">Die unitOfWork (<see cref="IUnitOfWork"/>)</param>
        /// <param name="faLeistungId">Die FaLeistungsID um die Positionen zu holen</param>
        /// <param name="datumBis">Datum, um das Valutadatum der Position einzuschränken.</param>
        /// <param name="includeFreigegebene"></param>
        /// <param name="offenePositionen">Out param. Beinhaltet alle offene Positionen (<see cref="List{WshAuszahlvorschlagPositionDTO}"/>)</param>
        /// <param name="belege">Out param. Beinhaltet eine Liste von Belegvorschlag (<see cref="List{WshAuszahlvorschlagBelegDTO}"/>)</param>
        /// <returns>Das <see cref="KissServiceResult"/></returns>
        public KissServiceResult GetAuszahlvorschlagPositionUndBeleg(
            IUnitOfWork unitOfWork,
            int faLeistungId,
            DateTime? datumBis,
            bool includeFreigegebene,
            out List<WshAuszahlvorschlagPositionDTO> offenePositionen,
            out List<WshAuszahlvorschlagBelegDTO> belege)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshPosition>(unitOfWork);

            // get alle offene Positionen
            var positionenQry = GetPositionen(repository, faLeistungId, datumBis, includeFreigegebene);
            offenePositionen = positionenQry.ToList();

            // get Belegvorschlag
            var belegvorschlag = GetBelegVorschlag(unitOfWork, offenePositionen, faLeistungId);
            var freigegebeneBelege = GetFreigegebeneBelege(unitOfWork, offenePositionen, faLeistungId, datumBis);

            //Sortieren: zuerst nach Valuta, (dann Insitutionen, dann Personen).
            belege = belegvorschlag.Union(freigegebeneBelege).OrderBy(x => x.Status.Value).ThenBy(x => x.Valuta).ThenByDescending(x => x.Kreditor.Type).ToList();

            return KissServiceResult.Ok();
        }

        /// <summary>
        /// Zum wissen ob für eine Leistung offenen Positionen vorhanden sind
        /// </summary>
        /// <param name="unitOfWork">Die unitOfWork (<see cref="IUnitOfWork"/>)</param>
        /// <param name="faLeistungId">Die FaLeistungsID um die Positionen zu holen</param>
        /// <returns>True wenn es noch offenen Positionen gibt, sonst false</returns>
        public bool HasOffenePositionen(IUnitOfWork unitOfWork, int faLeistungId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshPosition>(unitOfWork);
            var offenePositionenQry = GetPositionen(repository, faLeistungId, null, false);

            return offenePositionenQry.Count() > 0;
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Hohlt die freigegebenen Belege.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="positionen"></param>
        /// <param name="faLeistungId"></param>
        /// <param name="datumBis"></param>
        /// <returns></returns>
        private static List<WshAuszahlvorschlagBelegDTO> GetFreigegebeneBelege(IUnitOfWork unitOfWork, List<WshAuszahlvorschlagPositionDTO> positionen, int faLeistungId, DateTime? datumBis)
        {
            var repositoryBelege = UnitOfWork.GetRepository<KbuBeleg>(unitOfWork);
            var query = from beleg in repositoryBelege
                        let hauptPosition = beleg.KbuBelegPosition.Where(pos => pos.HauptPosition).FirstOrDefault()
                        let kreditor = beleg.KbuBelegKreditor.FirstOrDefault()
                        where beleg.KbuBelegPosition.Any(pos => pos.FaLeistungID == faLeistungId)
                        where datumBis == null || beleg.ValutaDatum <= datumBis
                        select new
                        {
                            PersonName = kreditor.BaZahlungsweg.BaPerson.Name,
                            PersonVorname = kreditor.BaZahlungsweg.BaPerson.Vorname,
                            InstitutionName = kreditor.BaZahlungsweg.BaInstitution.Name ?? kreditor.BaZahlungsweg.BaInstitution.InstitutionName,
                            beleg.ValutaDatum,
                            BankkontoNummer = kreditor.BaZahlungsweg.BankKontoNummer,
                            PostkontoNummer = kreditor.BaZahlungsweg.PostKontoNummer,
                            BankName = kreditor.BaZahlungsweg.BaBank.Name,
                            WshPositionen = beleg.KbuBelegPosition,
                            Betrag = hauptPosition.BetragNetto,
                        };

            var result = new List<WshAuszahlvorschlagBelegDTO>();
            foreach (var belegDaten in query)
            {
                var belegDTO = new WshAuszahlvorschlagBelegDTO();

                //BelegPositionen
                belegDTO.BelegPositionen = new List<WshAuszahlvorschlagBelegPositionDTO>();
                foreach (var pos in positionen)
                {
                    WshAuszahlvorschlagBelegPositionDTO posDTO = new WshAuszahlvorschlagBelegPositionDTO(belegDTO);

                    KbuBelegPosition belegPosition =
                        belegDaten.WshPositionen.Where(x => x.WshPositionID == pos.WshPosition.WshPositionID).SingleOrDefault();

                    if (belegPosition != null)
                    {
                        if ("S" == belegPosition.SollHaben)
                        {
                            posDTO.Ausgabe = belegPosition.BetragBrutto;
                            posDTO.Einnahme = 0;
                        }
                        else
                        {
                            posDTO.Ausgabe = 0;
                            posDTO.Einnahme = belegPosition.BetragBrutto;
                        }
                    }
                    else
                    {
                        posDTO.Ausgabe = null;
                        posDTO.Einnahme = null;
                    }

                    posDTO.WshPosition = pos.WshPosition;

                    belegDTO.BelegPositionen.Add(posDTO);
                }
                belegDTO.RegisterPositionPropertyChangedEventHandler();

                //Status
                belegDTO.Status = new WshAuszahlvorschlagStatusWrapper { Value = (int)WshAuszahlvorschlagStatus.Freigegeben };

                //ValutaDatum
                belegDTO.Valuta = belegDaten.ValutaDatum ?? new DateTime(1900, 1, 1);

                //Kreditorinfo
                WshAuszahlvorschlagKreditorDTO kreditorDTO = new WshAuszahlvorschlagKreditorDTO();

                //Person
                if (!string.IsNullOrEmpty(belegDaten.PersonName))
                {
                    kreditorDTO.Name = belegDaten.PersonName + " " + belegDaten.PersonVorname ?? "";
                    kreditorDTO.Type = KreditorType.Person;
                }

                //Institution
                else
                {
                    kreditorDTO.Name = belegDaten.InstitutionName;
                    kreditorDTO.Type = KreditorType.Institution;
                }

                //BankDaten
                kreditorDTO.BankName = belegDaten.BankName ?? "Post";
                kreditorDTO.PostKontoNr = belegDaten.PostkontoNummer;
                kreditorDTO.BankKontoNr = belegDaten.BankkontoNummer;
                kreditorDTO.KontoNr = belegDaten.BankkontoNummer ?? belegDaten.PostkontoNummer ?? "";
                belegDTO.Kreditor = kreditorDTO;

                result.Add(belegDTO);

            }

            return result;
        }

        /// <summary>
        /// Erstellt ein Query für alle offene WshPositionen
        /// und Positionen, welche in einem Vorbeleg enthalten sind.
        /// 
        /// Eine offene WshPosition ist wie folgt definiert:
        /// - Ausgabe und nicht abgetretene Einnamen
        /// - Der verfügbare Betrag ist noch nicht aufgebraucht (Summen sind kleiner als Betrag).
        /// 
        /// </summary>
        /// <param name="positionen"></param>
        /// <param name="faLeistungId"></param>
        /// <param name="datumBis">TODO: Kopieren</param>
        /// <param name="includeFreigegebene"></param>
        /// <returns></returns>
        private static IQueryable<WshAuszahlvorschlagPositionDTO> GetPositionen(IQueryable<WshPosition> positionen, int faLeistungId, DateTime? datumBis, bool includeFreigegebene)
        {
            int wshKategorieIdEinnahme = (int)LOVsGenerated.WshKategorie.Einnahme;

            return from pos in positionen
                   let betragVerfuegbar = Math.Abs(pos.Betrag) - (pos.KbuBelegPosition.Count() == 0
                                                                      ? 0
                                                                      : Math.Abs(
                                                                          pos.KbuBelegPosition.Where(x => x.HauptPosition == false).Sum(
                                                                              x => x.BetragBrutto)))
                   let isAusgabe = pos.WshKategorieID == (int)LOVsGenerated.WshKategorie.Ausgabe
                   let kreditor = pos.WshPositionKreditor.FirstOrDefault()

                   where pos.FaLeistungID == faLeistungId
                   where (pos.VerwaltungSD == false && pos.WshKategorieID == wshKategorieIdEinnahme) || pos.WshKategorieID != wshKategorieIdEinnahme //Abgetretene Einnahme nicht berücksichtigen.
                   where betragVerfuegbar > 0 || (pos.KbuBelegPosition.Count > 0 && includeFreigegebene)
                   where datumBis == null || !pos.FaelligAm.HasValue || pos.FaelligAm <= datumBis // ToDo: Periodizität berücksichtigen (1x, 2x monatlich, wöchentlich...)

                   orderby pos.MonatVon, pos.KbuKonto.KontoNr //todo In Vertiefungssprint redefinieren.
                   select (new WshAuszahlvorschlagPositionDTO
                   {
                       WshPosition = pos,
                       MonatVon = pos.MonatVon,
                       MonatBis = pos.MonatBis,
                       Kostenart = pos.KbuKonto.KontoNr,
                       Text = pos.Text,
                       Betrifft = pos.BaPerson,
                       Verfuegbar = isAusgabe ? betragVerfuegbar : -betragVerfuegbar,
                       IsAusgabe = isAusgabe,
                   });
        }

        /// <summary>
        /// Prüft, ob der Beleg für eine Person aus dem Haushalt ist.
        /// </summary>
        /// <param name="beleg"></param>
        /// <param name="faLeistungId"></param>
        /// <returns></returns>
        private static bool KreditorIstNichtDrittPerson(WshAuszahlvorschlagBelegDTO beleg, int faLeistungId)
        {
            DateTime stichtag = beleg.Valuta;

            if (beleg.Kreditor == null)
            {
                return true;
            }

            BaZahlungsweg zahlungsweg = null;

            if (beleg.Kreditor.BaZahlungsweg != null)
            {
                zahlungsweg = beleg.Kreditor.BaZahlungsweg;
            }

            if (zahlungsweg == null || !zahlungsweg.BaPersonID.HasValue)
            {
                return false;
            }

            var baPersonID = zahlungsweg.BaPersonID;
            var haushaltService = Container.Resolve<WshHaushaltPersonService>();
            var haushaltPersonen = haushaltService.GetHaushaltPersonen(null, faLeistungId, stichtag);

            return haushaltPersonen.Any(p => p.Unterstuetzt && p.BaPersonID == baPersonID);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Erstellt einen einzelnen Belegvorschlag oder ergänzt ihn.
        /// Siehe GetBelegVorschlag
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="positionDTO"></param>
        /// <param name="dictionary"></param>
        /// <param name="offenePositionenList"></param>
        private void AddWshAuszahlvorschlagPositionDTO(IUnitOfWork unitOfWork, WshAuszahlvorschlagPositionDTO positionDTO, IDictionary<BelegKey, WshAuszahlvorschlagBelegDTO> dictionary, List<WshAuszahlvorschlagPositionDTO> offenePositionenList)
        {
            var repositoryKreditor = UnitOfWork.GetRepository<WshPositionKreditor>(unitOfWork);
            var kreditor = repositoryKreditor.Where(x => x.WshPositionID == positionDTO.WshPosition.WshPositionID).SingleOrDefault();

            // Ausgaben haben immer einen Kreditor, Einnahmen haben immer nur einen Debitor.
            // Wir erstellen Belege nur für Ausgaben.
            if (kreditor == null)
            {
                return;
            }

            //Wenn der Betrag verfügbar <= 0 ist, dann soll kein BelegVorschlag erstellt werden.
            //Ist in der Liste, weil wir auch freigegebene Belege anzeigen.
            if (positionDTO.Verfuegbar <= 0)
            {
                return;
            }

            BelegKey belegKey = new BelegKey();

            if (kreditor.BaZahlungswegID.HasValue)
            {
                belegKey.BaZahlungswegID = kreditor.BaZahlungswegID.Value;
            }

            // Valuta-Datum aufgrund Periodizität bestimmen
            LOVsGenerated.WshPeriodizitaet wshPeriodizitaet;
            var hasPeriodizitaet = WshPositionMonatBudgetDTOService.GetPeriodizitaet(positionDTO.WshPosition.WshPeriodizitaetCode, out wshPeriodizitaet);

            // Valuta-Datum berechnen
            var zahlungslaufValutaService = Container.Resolve<KbuZahlungslaufValutaService>();
            var datumBerechnet = zahlungslaufValutaService.GetNextValutaDatum(
                unitOfWork, wshPeriodizitaet, positionDTO.WshPosition.MonatVon.Year, positionDTO.WshPosition.MonatVon.Month);

            if (!hasPeriodizitaet || wshPeriodizitaet == LOVsGenerated.WshPeriodizitaet.Valuta)
            {
                belegKey.ValutaDatum = positionDTO.WshPosition.FaelligAm ?? DateTime.Today;
            }
            else if (datumBerechnet < DateTime.Today)
            {
                //Alle Valuta-Dati der Vergangenheit werden pro Kreditor zu einem Beleg zusammengefasst.
                //Es ist ja nicht möglich, eine Zahlung in der Vergangenheit zu tätigen.
                belegKey.ValutaDatum = DateTime.Today;
            }
            else
            {
                belegKey.ValutaDatum = datumBerechnet ?? DateTime.Today;
            }

            WshAuszahlvorschlagBelegDTO belegDTO;
            if (!dictionary.TryGetValue(belegKey, out belegDTO))
            {

                belegDTO = new WshAuszahlvorschlagBelegDTO();

                //Valuta
                belegDTO.Valuta = belegKey.ValutaDatum;

                //KreditorDTO. Dieses Query funktioniert nicht mit MOCK.
                //TODO: Mock-Kompatibel machen.
                var query = from x in repositoryKreditor
                            where x.WshPositionID == positionDTO.WshPosition.WshPositionID
                            select new
                            {
                                WshPositionKreditor = x,
                                x.BaZahlungsweg,
                                PersonName = x.BaZahlungsweg.BaPerson != null ? x.BaZahlungsweg.BaPerson.Name : null,
                                PersonVorname = x.BaZahlungsweg.BaPerson != null ? x.BaZahlungsweg.BaPerson.Vorname : null,
                                InstitutionName = x.BaZahlungsweg.BaInstitution != null ? x.BaZahlungsweg.BaInstitution.Name ?? x.BaZahlungsweg.BaInstitution.InstitutionName : null,
                                BankkontoNummer = x.BaZahlungsweg.BankKontoNummer,
                                PostkontoNummer = x.BaZahlungsweg.PostKontoNummer,
                                BankName = x.BaZahlungsweg.BaBank != null ? x.BaZahlungsweg.BaBank.Name : null,
                            };

                var kreditorDaten = query.FirstOrDefault();
                if (kreditorDaten != null)
                {
                    WshAuszahlvorschlagKreditorDTO kreditorDTO = new WshAuszahlvorschlagKreditorDTO();

                    kreditorDTO.BaZahlungsweg = kreditorDaten.BaZahlungsweg;

                    //Person
                    if (!string.IsNullOrEmpty(kreditorDaten.PersonName))
                    {
                        kreditorDTO.Name = kreditorDaten.PersonName + " " + kreditorDaten.PersonVorname ?? "";
                        kreditorDTO.Type = KreditorType.Person;
                    }

                    //Institution
                    if (!string.IsNullOrEmpty(kreditorDaten.InstitutionName))
                    {
                        kreditorDTO.Name = kreditorDaten.InstitutionName;
                        kreditorDTO.Type = KreditorType.Institution;
                    }

                    //BankDaten
                    kreditorDTO.BankName = kreditorDaten.BankName ?? "Post";
                    kreditorDTO.KontoNr = kreditorDaten.BankkontoNummer ?? kreditorDaten.PostkontoNummer;
                    kreditorDTO.PostKontoNr = kreditorDaten.PostkontoNummer;
                    kreditorDTO.BankKontoNr = kreditorDaten.BankkontoNummer;
                    belegDTO.Kreditor = kreditorDTO;
                }

                //Status
                belegDTO.Status = new WshAuszahlvorschlagStatusWrapper { Value = (int)WshAuszahlvorschlagStatus.Vorschlag };

                //Positionen, zuerst mal mit 0 abfüllen. Die Werte werden später übertragen.
                belegDTO.BelegPositionen = new List<WshAuszahlvorschlagBelegPositionDTO>();
                foreach (var pos in offenePositionenList)
                {

                    WshAuszahlvorschlagBelegPositionDTO posDTO = new WshAuszahlvorschlagBelegPositionDTO(belegDTO);
                    posDTO.Ausgabe = null;
                    posDTO.Einnahme = null;
                    posDTO.WshPosition = pos.WshPosition;
                    belegDTO.BelegPositionen.Add(posDTO);
                }

                dictionary.Add(belegKey, belegDTO);
            }

            //BelegPosition Werte übertragen.
            WshAuszahlvorschlagBelegPositionDTO belegPositionDTO =
                belegDTO.BelegPositionen.Where(x => x.WshPosition.WshPositionID == positionDTO.WshPosition.WshPositionID).Select(x => x).Single();

            if (positionDTO.IsAusgabe)
            {
                belegPositionDTO.Ausgabe = positionDTO.Verfuegbar;
            }
            else
            {
                belegPositionDTO.Einnahme = -positionDTO.Verfuegbar;
            }

            //Ein BelegDTO enthält BelegPositionen (WshAuszahlvorschlagBelegPositionDTO).
            //Wir registrieren einen EventHandler, damit das belegDTO merkt, wenn sich die Werte in einer BelegPosition
            //geändert haben. Der Betrag muss dann z.B. neu berechnet werden.
            belegDTO.RegisterPositionPropertyChangedEventHandler();
        }

        /// <summary>
        /// Erstellt Belegvorschläge.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="offenePositionenQry"></param>
        /// <param name="faLeistungId"></param>
        /// <returns></returns>
        private List<WshAuszahlvorschlagBelegDTO> GetBelegVorschlag(IUnitOfWork unitOfWork, List<WshAuszahlvorschlagPositionDTO> offenePositionenQry, int faLeistungId)
        {
            List<WshAuszahlvorschlagPositionDTO> offenePositionenList = offenePositionenQry.ToList();
            if (offenePositionenList.Count == 0)
            {
                return new List<WshAuszahlvorschlagBelegDTO>();
            }

            IDictionary<BelegKey, WshAuszahlvorschlagBelegDTO> dictionary = new Dictionary<BelegKey, WshAuszahlvorschlagBelegDTO>();

            //Iteration über jede offene Position.
            foreach (var positionDTO in offenePositionenList)
            {
                AddWshAuszahlvorschlagPositionDTO(unitOfWork, positionDTO, dictionary, offenePositionenList);
            }

            // Belege nach Kreditor nicht DrittPerson sortieren
            //var belegMitKreditorOrderedList = dictionary.Values.OrderBy(b => !KreditorIstNichtDrittPerson(b, faLeistungId)).ToList();
            var belegMitKreditorOrderedList = dictionary.Values.ToList();

            // suche alle Positionen ohne Kreditor
            var belegPositionenOhneKreditorList = (from pos in offenePositionenQry
                                                   where pos.WshPosition.WshPositionKreditor.Count() == 0
                                                   select new
                                                   {
                                                       pos.WshPosition,
                                                       Ausgabe = pos.IsAusgabe ? pos.Verfuegbar : (decimal?)null,
                                                       Einnahme = !pos.IsAusgabe ? -pos.Verfuegbar : (decimal?)null,
                                                   }).ToList();

            // Die Werte für Einnahmen werden beim ersten Beleg hinzugefügt.
            // Der  Kreditor des ersten Belegs ist in der Regel der Klient selber.
            // Der Sachbearbeiter kann sie dann selber verteilen.
            // Positionen ohne Kreditor sind Einnahmen.
            if (belegPositionenOhneKreditorList.Count > 0 && belegMitKreditorOrderedList.Count > 0)
            {
                var belegPositionenList = belegMitKreditorOrderedList.First().BelegPositionen.ToList();

                foreach (var position in belegPositionenList)
                {
                    if (belegPositionenOhneKreditorList.Select(pok => pok.WshPosition).Contains(position.WshPosition))
                    {
                        var belegPositionOhneKreditor = belegPositionenOhneKreditorList.FirstOrDefault(p => p.WshPosition == position.WshPosition);
                        position.Ausgabe = belegPositionOhneKreditor.Ausgabe;
                        position.Einnahme = belegPositionOhneKreditor.Einnahme;
                    }
                }

                belegMitKreditorOrderedList.First().BelegPositionen = belegPositionenList;
            }

            return belegMitKreditorOrderedList;
        }

        #endregion

        #endregion
    }
}