using System.Linq;

using Kiss.BL;

using KiSS.Common.Exceptions;

using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Sst
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class SstPscdBelegPositionService : ServiceCRUDBase<SstPscdBelegPosition>
    {
        #region Methods

        #region Public Methods

        //public override KissServiceResult ValidateInMemory(TEntity dataToValidate)
        //{
        //    // validation: check if entity is consistent in itself
        //    var validator = new TValidator();
        //    var serviceResult = new KissServiceResult(validator.Validate(dataToValidate));

        //    return serviceResult + base.ValidateInMemory(dataToValidate);
        //}

        #endregion

        #endregion

        public override SstPscdBelegPosition GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<SstPscdBelegPosition>(unitOfWork);

            var returnValue = repository
                .Where(pos => pos.SstPscdBelegPositionID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'SstPscdBelegPosition' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        /// <summary>
        /// Erstellt einen SstPscdBelegPosition-Eintrag, der benötigt wird, um eine Buchung an PSCD zu übertragen
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="kbuBelegPositionID"></param>
        /// <param name="sachkonto"></param>
        /// <param name="innenauftrag"></param>
        /// <returns></returns>
        public KissServiceResult Insert(IUnitOfWork unitOfWork, int kbuBelegPositionID, string sachkonto, string innenauftrag)
        {
            var result = KissServiceResult.Ok();
            SstPscdBelegPosition newData;
            result += base.NewData(out newData);
            if( result.IsError)
            {
                return result;
            }
            newData.KbuBelegPositionID = kbuBelegPositionID;
            newData.Sachkonto = sachkonto;
            newData.Innenauftrag = innenauftrag;

            result += base.SaveData(unitOfWork, newData);

            return result;
        }
    }
}