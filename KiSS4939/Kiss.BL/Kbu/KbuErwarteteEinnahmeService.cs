using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BL;

using KiSS.Common.Exceptions;

using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Model;
using Kiss.Model.DTO.Kbu;

namespace Kiss.BL.Kbu
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class KbuErwarteteEinnahmeService : ServiceBase
    {
        #region Methods

        #region Public Methods

        public IList<KbuErwarteteEinnahmeDTO> GetOffeneErwarteteEinnahmenByFaFallID(IUnitOfWork unitOfWork, int faFallID, bool skipAusgeglichene, int? baPersonIDKlient, int? baInstitutionIDDebitor, int? baPersonIDDebitor)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<WshPosition>(unitOfWork);

            var result = from wshPosition in repository
                         where wshPosition.FaLeistung.FaFallID == faFallID &&
                               (!baPersonIDKlient.HasValue || wshPosition.BaPersonID == baPersonIDKlient.Value) &&
                               wshPosition.WshKategorieID == (int)LOVsGenerated.WshKategorie.Einnahme &&
                               wshPosition.VerwaltungSD &&
                               wshPosition.WshPositionDebitor.Count == 1 &&
                               wshPosition.KbuKonto != null
                         let debitor = wshPosition.WshPositionDebitor.FirstOrDefault() // ToDo: weitere Debitoren berücksichtigen?
                         let debitorPerson = debitor.BaPerson
                         let debitorInstitution = debitor.BaInstitution
                         let betragAusgeglichen = wshPosition.KbuBelegPosition.Count == 0 ? 0m : wshPosition.KbuBelegPosition.Sum(ausgleich => ausgleich.BetragBrutto)
                         where !skipAusgeglichene || betragAusgeglichen != wshPosition.Betrag
                         select new
                                   {
                                       WshPosition = wshPosition,
                                       BaInstitutionIDDebitor = debitor.BaInstitutionID,
                                       BaPersonIDDebitor = debitor.BaPersonID,
                                       KbuKontoID = wshPosition.KbuKontoID,
                                       KontoNr = wshPosition.KbuKonto.KontoNr,
                                       DebitorText = debitorInstitution != null ? debitorInstitution.Name : debitorPerson != null ? debitorPerson.Name + ", " + debitorPerson.Vorname : string.Empty,
                                       //Kostenstelle = null, //ToDo: Kostenstelle bestimmen, neu wohl über FaLeistung.OrgUnitID
                                       BetragTotal = wshPosition.Betrag,
                                       BetragAusgeglichen = wshPosition.KbuBelegPosition.Count == 0 ? 0m : wshPosition.KbuBelegPosition.Sum(ausgleich => ausgleich.BetragBrutto) // ToDo: stornierte Belege nicht berücksichtigen (DB gibt diese Info noch nicht her)
                                   };

            var positionen = result.ToList().Select(pos => new KbuErwarteteEinnahmeDTO
            {
                WshPositionID = pos.WshPosition.WshPositionID,
                BetragTotal = pos.WshPosition.Betrag,
                BaInstitutionIDDebitor = pos.BaInstitutionIDDebitor,
                BaPersonIDDebitor = pos.BaPersonIDDebitor,
                FaelligAm = pos.WshPosition.MonatVon, // ToDo: Fälligkeitsdatum bestimmen
                KbuKontoID = pos.KbuKontoID,
                KontoNr = pos.KontoNr,
                Text = pos.WshPosition.Text,
                BetragAuszugleichen = 0m,
                Verwendungsperiode = new TimePeriod(pos.WshPosition.VerwPeriodeVon, pos.WshPosition.VerwPeriodeBis),
                DebitorText = pos.DebitorText,
                //Kostenstelle = pos.Kostenstelle,
                BetragOffen = pos.BetragTotal - pos.BetragAusgeglichen
            });

            return positionen.ToList();
        }

        public IList<KbuErwarteteEinnahmeDTO> GetAusgeglicheneErwarteteEinnahmenByKbuZahlungseingang(IUnitOfWork unitOfWork, KbuZahlungseingang kbuZahlungseingang)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuBelegPosition>(unitOfWork);

            var positionen = from bp in repository
                                   where bp.KbuBeleg.KbuZahlungseingangID == kbuZahlungseingang.KbuZahlungseingangID && bp.WshPosition != null
                                   let pos = bp.WshPosition
                                   let debitor = pos.WshPositionDebitor.FirstOrDefault()
                                   let debitorPerson = debitor.BaPerson
                                   let debitorInstitution = debitor.BaInstitution
                                   select new
                                   {
                                       WshPosition = pos,
                                       BaInstitutionIDDebitor = debitor.BaInstitutionID,
                                       BaPersonIDDebitor = debitor.BaPersonID,
                                       KbuKonto = pos.KbuKonto,
                                       DebitorText = debitorInstitution != null ? debitorInstitution.Name : debitorPerson != null ? debitorPerson.Name + ", " + debitorPerson.Vorname : string.Empty,
                                       BetragTotal = pos.Betrag,
                                       BetragAusgeglichenTotal = pos.KbuBelegPosition.Count == 0 ? 0m : pos.KbuBelegPosition.Sum(ausgleich => ausgleich.BetragBrutto), // ToDo: stornierte Belege nicht berücksichtigen (DB gibt diese Info noch nicht her
                                       BetragAusgeglichenPosition = bp.BetragBrutto,
                                   };

            //var result = from pos in positionen
            //             select new KbuErwarteteEinnahmeDTO
            //             {
            //                 WshPositionID = pos.WshPosition.WshPositionID,
            //                 BetragTotal = pos.WshPosition.Betrag,
            //                 BaInstitutionIDDebitor = pos.BaInstitutionIDDebitor,
            //                 BaPersonIDDebitor = pos.BaPersonIDDebitor,
            //                 //FaelligAm = new DateTime(pos.WshPosition.Jahr, pos.WshPosition.Monat, 1),
            //                 KbuKontoID = pos.KbuKonto.KbuKontoID,
            //                 KontoNr = pos.KbuKonto.KontoNr,
            //                 Text = pos.WshPosition.Text,
            //                 BetragAuszugleichen = pos.BetragAusgeglichenPosition,
            //                 //Verwendungsperiode = new TimePeriod(pos.WshPosition.VerwPeriodeVon, pos.WshPosition.VerwPeriodeBis),
            //                 DebitorText = pos.DebitorText,
            //                 BetragOffen = pos.BetragTotal - pos.BetragAusgeglichenTotal
            //             };

            var result = from pos in positionen.ToList()
                         select new KbuErwarteteEinnahmeDTO
                         {
                             WshPositionID = pos.WshPosition.WshPositionID,
                             BetragTotal = pos.WshPosition.Betrag,
                             BaInstitutionIDDebitor = pos.BaInstitutionIDDebitor,
                             BaPersonIDDebitor = pos.BaPersonIDDebitor,
                             FaelligAm = pos.WshPosition.MonatVon, // ToDo: Fälligkeitsdatum bestimmen
                             KbuKontoID = pos.KbuKonto.KbuKontoID,
                             KontoNr = pos.KbuKonto.KontoNr,
                             Text = pos.WshPosition.Text,
                             BetragAuszugleichen = pos.BetragAusgeglichenPosition,
                             Verwendungsperiode = new TimePeriod(pos.WshPosition.VerwPeriodeVon, pos.WshPosition.VerwPeriodeBis),
                             DebitorText = pos.DebitorText,
                             BetragOffen = pos.BetragTotal - pos.BetragAusgeglichenTotal
                         };

            return result.ToList();
        }

        #endregion

        #endregion
    }
}