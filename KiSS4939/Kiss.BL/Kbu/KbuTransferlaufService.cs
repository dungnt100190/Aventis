using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Kiss.BL.KbuTransferlaufWebService;
using Kiss.BL.KissSystem;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Kbu;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Kbu
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class KbuTransferlaufService : ServiceCRUDBase<KbuTransferlauf>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CONFIGPATH_KBUTRANSFERLAUFSERVICE_ADDRESS = @"System\Schnittstellen\PSCD\TransferlaufURL";
        private const string ENDPOINT_KBUTRANSFERLAUFSERVICE = "Endpoint_BasicHttpBinding_IKbuTransferlaufWebService";

        #endregion

        #endregion

        #region Constructors

        private KbuTransferlaufService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Stoppt den Transferlauf.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="kbuTransferlaufID"></param>
        public KissServiceResult CancelTransferlauf(IUnitOfWork unitOfWork, int kbuTransferlaufID)
        {
            var client = GetClient(unitOfWork);
            var session = Container.Resolve<ISessionService>();
            return client.CancelTransferlauf(session.DatabaseName, GetUser(session), kbuTransferlaufID);
        }

        /// <summary>
        /// Erstellt einen Transferlauf und startet dessen Verarbeitung im Server
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="kbuBelegIDs">IDs der zu übertragenden Belege</param>
        /// <param name="kbuTransferlaufID">ID des erstellten Transferlaufs</param>
        /// <returns></returns>
        public KissServiceResult CreateAndStartTransferlauf(IUnitOfWork unitOfWork, IEnumerable<int> kbuBelegIDs, out int? kbuTransferlaufID)
        {
            var result = KissServiceResult.Ok();
            kbuTransferlaufID = null;

            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            using (var trx = new TransactionScope())
            {
                if (kbuBelegIDs == null)
                {
                    // Keine Belege mitgegeben -> alle transferierbaren Belege übermitteln
                    var belege = GetTransferierbareBelege(unitOfWork, false);
                    kbuBelegIDs = belege.Select(beleg => beleg.KbuBelegID);
                    if (kbuBelegIDs.Count() == 0)
                    {
                        return new KissServiceResult(KissServiceResult.ResultType.Error, "KbuTransferlaufService_NoTransferableKbuBeleg", "Es gibt keine transferierbaren Belege");
                    }
                }

                var transferlauf = CreateTransferlaufOrGetPending(unitOfWork);
                if (transferlauf.KbuTransferlaufStatusCode == (int)LOVsGenerated.KbuTransferlaufStatus.Running)
                {
                    kbuTransferlaufID = transferlauf.KbuTransferlaufID;
                    return new KissServiceResult(KissServiceResult.ResultType.Error, "KbuTransferlaufService_ExistingKbuTransferlauf", "Es läuft bereits ein Zahllauf");
                }

                var transferlaufBelegService = Container.Resolve<KbuTransferlaufKbuBelegService>();
                foreach (var kbuBelegID in kbuBelegIDs)
                {
                    KbuTransferlauf_KbuBeleg newTransferlaufBeleg;
                    result += transferlaufBelegService.NewData(out newTransferlaufBeleg);
                    if (!result)
                    {
                        return result;
                    }
                    newTransferlaufBeleg.KbuTransferlauf = transferlauf;
                    newTransferlaufBeleg.KbuBelegID = kbuBelegID;
                    result += transferlaufBelegService.SaveData(unitOfWork, newTransferlaufBeleg);
                }
                if (!result)
                {
                    return result;
                }
                trx.Complete();
                kbuTransferlaufID = transferlauf.KbuTransferlaufID;
            }

            var session = Container.Resolve<ISessionService>();
            try
            {
                var client = GetClient(unitOfWork);
                result += client.StartTransferlauf(session.DatabaseName, GetUser(session), kbuTransferlaufID.Value);
            }
            catch (Exception ex)
            {
                result += ProcessServerCallError(ex);
            }
            return result;
        }

        private static KissServiceResult ProcessServerCallError(Exception ex)
        {
            var notFoundEx = ex as System.ServiceModel.EndpointNotFoundException;
            if( notFoundEx != null)
            {
                return new KissServiceResult(
                    KissServiceResult.ResultType.Error,
                    "KbuTransferlaufService_EndpointNotFound",
                    "Verbindung zum KiSS-Server ist nicht möglich. Entweder ist dieser Client falsch konfiguriert oder der Server läuft nicht.");
            }
            return KissServiceResult.Error(ex);
        }

        /// <summary>
        /// Gibt den Transferlauf zurück, 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public KbuTransferlauf CreateTransferlaufOrGetPending(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuTransferlauf>(unitOfWork);

            var pendingTransferlauf = repository
                 .Where(transferlauf => transferlauf.KbuTransferlaufStatusCode == (int)LOVsGenerated.KbuTransferlaufStatus.Created ||
                                        transferlauf.KbuTransferlaufStatusCode == (int)LOVsGenerated.KbuTransferlaufStatus.Running)
                 .SingleOrDefault(); // Durch DB-Contraint wird sichergestellt, dass nur ein Transferlauf pendent ist

            if (pendingTransferlauf == null)
            {
                base.NewData(out pendingTransferlauf);
                pendingTransferlauf.KbuTransferlaufStatusCode = (int)Infrastructure.Constant.LOVsGenerated.KbuTransferlaufStatus.Created;
                SaveData(unitOfWork, pendingTransferlauf);
            }

            SetEntityValidator(pendingTransferlauf);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return pendingTransferlauf;
        }

        public override KbuTransferlauf GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuTransferlauf>(unitOfWork);

            var returnValue = repository
                .Where(transferlauf => transferlauf.KbuTransferlaufID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'KbuTransferlauf' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        //public override KissServiceResult ValidateInMemory(KbuTransferlauf dataToValidate)
        //{
        //    // validation: check if entity is consistent in itself
        //    var validator = new TValidator();
        //    var serviceResult = new KissServiceResult(validator.Validate(dataToValidate));
        //    return serviceResult + base.ValidateInMemory(dataToValidate);
        //}


        /// <summary>
        /// Hohlt Belege, welche ans PSCD übermittelt werden könnten.
        /// Bedingungen:
        /// -  Belege, welche schon nicht erfolgreich ans PSCD transferiert wurden.
        /// -  Belege im status verbucht.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="valutaBis"></param>
        /// <param name="showOnlyErrors"></param>
        /// <returns></returns>
        public List<KbuBelegLaufDTO> GetTransferierbareBelege(IUnitOfWork unitOfWork, bool showOnlyErrors)
        {
            //Mock implementation
            var list = new List<KbuBelegLaufDTO>();

            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuBeleg>(unitOfWork);

            var belege = from kbuBeleg in repository
                         where kbuBeleg.KbuBelegstatusCode == (int)LOVsGenerated.KbuBelegstatus.Verbucht &&
                               kbuBeleg.ValutaDatum.HasValue &&
                               !kbuBeleg.TransferDatum.HasValue &&
                               (kbuBeleg.Fehlermeldung != null || !showOnlyErrors)
                         let erstePosition = kbuBeleg.KbuBelegPosition.Where(pos => pos.HauptPosition == false).FirstOrDefault() //Für Sprint 6 zeigen wir die Infos von der 1. Belegposition.
                         let leistungErstePosition = erstePosition != null ? erstePosition.FaLeistung : null
                         let personErstePosition = leistungErstePosition != null ? leistungErstePosition.BaPerson : null
                         select new KbuBelegLaufDTO
                         {
                             KbuBelegID = kbuBeleg.KbuBelegID,
                             ValutaDatum = kbuBeleg.ValutaDatum,
                             Betrag = kbuBeleg.KbuBelegPosition.Where(x => x.HauptPosition).FirstOrDefault().BetragBrutto,
                             Selected = true,
                             Text = kbuBeleg.Text,
                             ErrorMessage = kbuBeleg.Fehlermeldung,
                             FaFallID = leistungErstePosition != null ? (int?)leistungErstePosition.FaFallID : null,
                             Klient = personErstePosition != null ? personErstePosition.Name + ", " + personErstePosition.Vorname : "",
                             Belegnummer = kbuBeleg.BelegNr
                         };

            var belegList = belege.ToList();
            return belegList;
            //return belegList.Select(tmp => new KbuBelegLaufDTO
            //                                   {
            //                                       KbuBelegID = tmp.KbuBelegID,
            //                                       ValutaDatum = tmp.ValutaDatum,
            //                                       Betrag = tmp.Betrag,
            //                                       Selected = true,
            //                                       Text = tmp.Text,
            //                                       ErrorMessage = tmp.ErrorMessage ?? "",
            //                                       FaFallID = tmp.FaFallID,
            //                                       Klient = tmp.Klient != null ? tmp.Klient.NameVorname : "",
            //                                       Belegnummer = tmp.Belegnummer
            //                                   }).ToList();
        }

        /// <summary>
        /// Berechnet den Fortschritt des Transferlaufs.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="kbuTransferlaufID"></param>
        /// <returns></returns>
        public KbuTransferlaufStateDTO GetVerarbeitungsProgress(IUnitOfWork unitOfWork)
        {
            var client = GetClient(unitOfWork);
            var session = Container.Resolve<ISessionService>();
            return client.GetTransferlaufProgress(session.DatabaseName, GetUser(session));
        }

        #endregion

        #region Private Static Methods

        private static KbuTransferlaufWebServiceClient GetClient(IUnitOfWork unitOfWork)
        {
            var configService = Container.Resolve<XConfigService>();
            var remoteAddress = configService.GetConfigValue<string>(unitOfWork, CONFIGPATH_KBUTRANSFERLAUFSERVICE_ADDRESS) ??
                                @"http://chbehvs006.chbe01.local:8000/Kiss.Server.PSCD/";
            //remoteAddress = @"http://localhost:8000/Kiss.Server.PSCD/"; // debug
            //remoteAddress = @"http://chbehvs006.chbe01.local:8000/Kiss.Server.PSCD/";
            return new KbuTransferlaufWebServiceClient(ENDPOINT_KBUTRANSFERLAUFSERVICE, remoteAddress);
        }

        private static DateTime GetDefaultTransferValuta()
        {
            return DateTime.Today.AddDays(1); // ToDo: WE und Feiertage berücksichtigen
        }

        private static KbuTransferlaufWebService.SerializableUser GetUser(ISessionService session)
        {
            if (session == null || session.AuthenticatedUser == null)
            {
                return null;
            }
            return new KbuTransferlaufWebService.SerializableUser
            {
                UserID = session.AuthenticatedUser.UserID,
                FirstName = session.AuthenticatedUser.FirstName,
                LastName = session.AuthenticatedUser.LastName,
                LogonName = session.AuthenticatedUser.LogonName,
                IsUserAdmin = session.AuthenticatedUser.IsUserAdmin,
                IsUserBIAGAdmin = session.AuthenticatedUser.IsUserBIAGAdmin,
                CreatorModifier = session.AuthenticatedUser.CreatorModifier
            };
        }

        #endregion

        #endregion
    }
}