using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

using Kiss.BL.Kbu.Validation;
using Kiss.BL.KissSystem;
using Kiss.Infrastructure;
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
    public class KbuKontoService : ServiceCRUDBase<KbuKonto>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string SPEZIALRECHT_MULTIFUNKTIONALES_VORZEICHEN = "MultiFunktionalesVorzeichen";

        #endregion

        #endregion

        #region Constructors

        private KbuKontoService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Gibt alle KontoIds von Konto die GBL sind.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork</param>
        /// <returns>Liste mit GLB-KontoIds</returns>
        public List<int> GetAllGblKontoIds(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuKonto>(unitOfWork);

            return repository
                .Where(kto => kto.KbuKonto_KbuKontoTyp.Any(typ => typ.KbuKontoTypCode == (int)LOVsGenerated.KbuKontoTyp.GBL))
                .Select(kto => kto.KbuKontoID)
                .ToList();
        }

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
        /// Sucht nach dem Konto für den GBL.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns>Wenn es kein GBL Konto gibt, dann wird null retourniert.</returns>
        public KbuKonto GetGblKonto(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuKonto>(unitOfWork);

            int kbuKontoTypCodeGBL = (int) LOVsGenerated.KbuKontoTyp.GBL;

            var query = from x in repository
                        where x.KbuKonto_KbuKontoTyp.Any(t => t.KbuKontoTypCode == kbuKontoTypCodeGBL)
                        select x;

            return query.FirstOrDefault();
        }

        public KbuKonto GetKlaerfallKonto(IUnitOfWork unitOfWork, string zahlstapelPrefix)
        {
            if (string.IsNullOrEmpty(zahlstapelPrefix))
                return null;

            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuKonto>(unitOfWork);

            var returnValue = repository
                .Where(konto => zahlstapelPrefix.Equals(konto.ExterneKontoNr, StringComparison.CurrentCultureIgnoreCase))
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("Es wurde kein Klaerfallkonto gefunden für den Präfix: " + zahlstapelPrefix);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Suche nach einem Konto anhand der KontoKlasse
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="kontoKlasse"></param>
        /// <returns></returns>
        public IList<KbuKonto> SearchKonto(IUnitOfWork unitOfWork, LOVsGenerated.KbuKontoklasse kontoKlasse)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuKonto>(unitOfWork);
            var query = from x in repository
                        where x.KbuKontoklasseCode == (int)kontoKlasse
                        select x;

            var result = query.ToList();
            result.ForEach(SetEntityValidator);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return result;
        }

        public override KissServiceResult ValidateInMemory(KbuKonto dataToValidate)
        {
            // validation: check if entity is consistent in itself
            var serviceResult = KbuKontoValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Überprüft, ob der angemeldete Benutzer das Spezialrecht
        /// "Multifunktionales Vorzeichen" besitzt.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public static bool HatSpezialrechtMultifunktionalesVorzeichen(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            //Spezialrecht auflösen.
            var sessionService = Container.Resolve<ISessionService>();
            var berechtigunsService = Container.Resolve<BerechtigungsService>();
            if (sessionService.AuthenticatedUser == null)
            {
                throw new Exception("Kein autentifizierter Benutzer in der Session vorhanden.");
            }

            int userID = sessionService.AuthenticatedUser.UserID;
            return berechtigunsService.HatUserSpezialrecht(unitOfWork, userID, SPEZIALRECHT_MULTIFUNKTIONALES_VORZEICHEN);
        }

        #endregion

        #endregion
    }
}
