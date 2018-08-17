using System.Collections.Generic;
using System.Linq;

using Kiss.BL;
using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Sst
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class SstPscdSachkontoInnenauftragService : ServiceCRUDBase<SstPscdSachkontoInnenauftrag>
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Liefert alle Einträge aus SstPscdSachkontoInnenauftrag zurück
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public List<SstPscdSachkontoInnenauftrag> GetAll(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var repository = UnitOfWork.GetRepository<SstPscdSachkontoInnenauftrag>(unitOfWork);

            var result = repository.ToList();

            result.ForEach(SetEntityValidator);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return result.ToList();
        }

        //public override KissServiceResult ValidateInMemory(SstPscdSachkontoInnenauftrag dataToValidate)
        //{
        //    // validation: check if entity is consistent in itself
        //    var validator = new TValidator();
        //    var serviceResult = new KissServiceResult(validator.Validate(dataToValidate));
        //    return serviceResult + base.ValidateInMemory(dataToValidate);
        //}
        
        public override SstPscdSachkontoInnenauftrag GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            var repository = UnitOfWork.GetRepository<SstPscdSachkontoInnenauftrag>(unitOfWork);

            var result = repository
                         .SingleOrDefault(x => x.SstPscdSachkontoInnenauftragID == id);

            if (result == null)
            {
                throw new EntityNotFoundException("No entity of type 'SstPscdSachkontoInnenauftrag' found with id: " + id);
            }

            SetEntityValidator(result);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return result;
        }

        #endregion

        #endregion
    }
}