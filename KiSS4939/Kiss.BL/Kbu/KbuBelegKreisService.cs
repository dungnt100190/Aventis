using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BL.Kbu.Validation;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Kbu
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class KbuBelegKreisService : ServiceCRUDBase<KbuBelegKreis>
    {
        #region Constructors

        private KbuBelegKreisService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public override KbuBelegKreis GetById(IUnitOfWork unitOfWork, int id)
        {
            throw new NotImplementedException("Do not use this method");
        }

        /// <summary>
        /// Lädt einen Datensatz aufgrund des LOV-Codes.
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork.</param>
        /// <param name="belegKreis">Der LOV-Code des Datensatzes.</param>
        /// <returns>Der Datensatz mit der angegebenen ID.</returns>
        public KbuBelegKreis GetByIdLOV(IUnitOfWork unitOfWork, LOVsGenerated.KbuBelegKreis belegKreis)
        {
            int codeLOV = (int)belegKreis;
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<KbuBelegKreis>(unitOfWork);

            var returnValue = repository
                .Where(id => id.KbuBelegKreisCode == codeLOV)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'KbuBelegKreis' found with LOV-id: " + codeLOV);
            }

            //SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Reserviert die nächsten Belegkreisnummern.
        /// TODO: PESSIMISTIC LOCKING EINBAUEN.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="belegKreisCode">Belegkreis-Nummer</param>
        /// <param name="size">Anzahl nummern, die reserviert werden sollen</param>
        /// <returns>Die nächste freie Nummer</returns>
        public int GetNextSequence(IUnitOfWork unitOfWork, LOVsGenerated.KbuBelegKreis belegKreisCode, int size)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            KbuBelegKreis belegKreis = GetByIdLOV(unitOfWork, belegKreisCode);
            int? nextValue = belegKreis.NaechsteBelegNr;
            if (!nextValue.HasValue)
            {
                throw new ConfigurationException("Für BelegKreis {0} ist keine nächste Nummer eingetragen.");
            }
            belegKreis.NaechsteBelegNr = nextValue.Value + size;
            if (belegKreis.NaechsteBelegNr.Value > belegKreis.BelegNrBis)
            {
                throw new ConfigurationException("Belegkreisnummern sind aufgebraucht.");
            }
            SaveData(unitOfWork, belegKreis);
            return nextValue.Value;
        }

        public override KissServiceResult SaveData(IUnitOfWork unitOfWork, List<KbuBelegKreis> dataToSave)
        {
            throw new NotImplementedException("Do not call this Method");
        }

        /// <summary>
        /// Validierung
        /// </summary>
        /// <param name="dataToValidate"></param>
        /// <returns></returns>
        public override KissServiceResult ValidateInMemory(KbuBelegKreis dataToValidate)
        {
            // validation: check if entity is consistent in itself
            var validator = new KbuBelegKreisValidator();

            var serviceResult = new KissServiceResult(validator.Validate(dataToValidate));

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #endregion
    }
}