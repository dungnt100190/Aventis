using System;
using System.Linq;
using System.Transactions;

using Kiss.BL.Fa;
using Kiss.BL.KissSystem;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Wsh
{
    /// <summary>
    /// Service to manage FaLeistung for the WSH module.
    /// </summary>
    public class WshLeistungService : FaLeistungService
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CONFIG_WSH_WOHNSITUATION = @"System\WSH\WohnsituationFeatureAvailable";
        private const int MODULID_WSH = 103;

        #endregion

        #endregion

        #region Constructors

        private WshLeistungService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Erstellt eine neue Leistung für WSH.
        /// Die für die Leistung zuständiger User ist der aktuell angemedete User, wenn
        /// das Property "UserId" im DTO null ist.
        /// Einträge in WshHaushaltPerson werden anhand der Daten im Basismodul erstellt:
        ///   ZH: Die Wohnsituation wird berücksichtigt.
        ///   Standard: Das Klientensystem wird berücksichtigt. Personen mit gleicher Adresse werden eingefügt.
        /// </summary>
        /// <param name="data">Daten für das Erstellen der Leistung</param>
        /// <param name="unitOfWork">UnitOfWork, kann null sein. Wenn null, wird neues UnitOfWork gestartet.</param>
        /// <param name="leistung">Die erstellte Leistung</param>
        /// <returns>Resultat der Erstellung</returns>
        public KissServiceResult InsertExistenzsicherungLeistung(IUnitOfWork unitOfWork, WshCreateLeistungDTO data, out FaLeistung leistung)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            using (var ts = new TransactionScope())
            {
                var result = KissServiceResult.Ok();
                var fallService = Container.Resolve<FaFallService>();
                var fallId = fallService.GetAktuelleFaFallId(unitOfWork, data.BaPersonId);
                if (!fallId.HasValue || fallId == 0)
                {
                    result += new KissServiceResult(KissServiceResult.ResultType.Error, "WshLeistungService_NoFaFall", "Person {0} hat keinen laufenden Fall. Bitte eröffnen Sie zuerst einen Fall im Modul F", data.BaPersonId);
                    leistung = null;
                    return result;
                }

                var leistungService = Container.Resolve<FaLeistungService>();

                leistungService.NewData(out leistung);
                leistung.BaPersonID = data.BaPersonId;
                leistung.DatumVon = data.DatumVon;
                leistung.ModulID = MODULID_WSH;
                leistung.FaProzessCode = (int)LOVsGenerated.FaProzess.Existenzsicherung;

                if (!data.UserId.HasValue)
                {
                    SessionService sessionService = Container.Resolve<SessionService>();
                    leistung.UserID = sessionService.AuthenticatedUser.UserID;
                }
                else
                {
                    leistung.UserID = data.UserId.Value;
                }
                leistung.FaFallID = fallId.Value;

                result += leistungService.SaveData(unitOfWork, leistung);

                //Einträge erstellen. Für ZH und für Standard gibt es eine eigene Version.
                WshHaushaltPersonService haushaltService = Container.Resolve<WshHaushaltPersonService>();
                XConfigService configService = Container.Resolve<XConfigService>();
                int wohnsituationFeatureAvailable = configService.GetConfigValue<int>(unitOfWork, CONFIG_WSH_WOHNSITUATION);

                if (wohnsituationFeatureAvailable == 1)
                {
                    haushaltService.CreateHaushaltFromWohnsituation(unitOfWork, leistung);
                }
                else
                {
                    haushaltService.CreateHaushaltFromAdresse(unitOfWork, leistung);
                }

                ts.Complete();
                return result;
            }
        }


        /// <summary>
        /// Liefert true zurück, wenn für die Monatsbudgetpositionen von Grundbudgetpositionen
        /// automatisch KbuBelegPositionen erstellt werden sollen.       
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="faLeistungID"></param>
        /// <returns></returns>
        public bool IsDauerauftragGrundbudgetAktiviert(IUnitOfWork unitOfWork, int faLeistungID)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);
            bool result = repository.Where(x => x.FaLeistungID == faLeistungID).Select(x => x.WshDauerauftragAktiv).Single();
            return result; //einfacher fürs debuggen. 
        }

        public override KissServiceResult SaveData(IUnitOfWork unitOfWork, FaLeistung dataToSave)
        {
            KissServiceResult result = base.SaveData(unitOfWork, dataToSave);
            if (result.IsError)
            {
                return result;
            }

            // Wenn das Datum von verändert worden ist, muss die berechnete GBL Position
            // vom betroffenen Monatsbudget angepasst werden.
            var budgetUebertragenService = Container.Resolve<WshGrundbudgetUebertragenService>();
            result += budgetUebertragenService.GblAnLeistungAnpassen(unitOfWork, dataToSave.FaLeistungID, dataToSave.DatumVon);

            return result;
        }

        public override KissServiceResult ValidateOnDatabase(IUnitOfWork unitOfWork, FaLeistung dataToValidate)
        {
            var result = base.ValidateOnDatabase(unitOfWork, dataToValidate);

            if (dataToValidate == null || (dataToValidate.FaProzessCode != (int)LOVsGenerated.FaProzess.Existenzsicherung &&
                                           dataToValidate.FaProzessCode != (int)LOVsGenerated.FaProzess.Platzierung) ||
                dataToValidate.ChangeTracker.State != ObjectState.Modified)
            {
                return result;
            }

            // Bei WSH-Leistungen darf das DatumVon nur unter bestimmten Bedingungen editiert werden
            var repository = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);
            var leistungOnDB = repository
                                .Where(l => l.FaLeistungID == dataToValidate.FaLeistungID)
                                .Select(x => new
                                {
                                    x.DatumVon,
                                    AnzahlGrundbudgetpositionen = x.WshGrundbudgetPosition.Count,
                                    AnzahlBelegPositionen = x.KbuBelegPosition.Count
                                })
                                .Single();

            DateTime datumVonOriginal = leistungOnDB.DatumVon;
            if (datumVonOriginal != dataToValidate.DatumVon)
            {
                // Solange noch keine Grundbudgetpositionen existieren darf das DatumVon beliebig verändert werden
                bool existierenGBPositionen = leistungOnDB.AnzahlGrundbudgetpositionen > 0;
                if (!existierenGBPositionen)
                {
                    return result;
                }

                // Sobald Belege existieren darf das DatumVon nicht mehr verändert werden
                bool existierenBelege = leistungOnDB.AnzahlBelegPositionen > 0; // "graue" Belege existieren auf der DB nicht, daher ist kein Filter auf den KbuBelegStatus nötig
                if (existierenBelege)
                {
                    result += new KissServiceResult(KissServiceResult.ResultType.Error,
                                                    "FaLeistungService_DatumVonNichtVeraenderbar",
                                                    "Es existieren bereits grüne und/oder gelbe Belege in dieser WSH-Leistung, deshalb darf das 'Datum von' nicht mehr verändert werden");
                }
                else
                {
                    // Keine Belege, aber Grundbudgetpositionen: DatumVon darf innerhalb des Monats verändert werden
                    bool gleicherMonat = (datumVonOriginal.Month == dataToValidate.DatumVon.Month && datumVonOriginal.Year == dataToValidate.DatumVon.Year);
                    if (!gleicherMonat)
                    {
                        result += new KissServiceResult(KissServiceResult.ResultType.Error,
                                                        "FaLeistungService_NurGleicherMonat",
                                                        "Es existieren bereits Grundbudgetpositionen in dieser WSH-Leistung, deshalb darf das 'Datum von' nur noch innerhalb des gleichen Monats ({0:MMMM yyyy}) verändert werden", datumVonOriginal);
                    }
                }
            }
            return result;
        }

        #endregion

        #endregion
    }
}