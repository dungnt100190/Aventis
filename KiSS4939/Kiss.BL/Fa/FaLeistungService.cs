using System;
using System.Linq;

using Kiss.BL.Fa.Validation;
using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Fa
{
    /// <summary>
    /// Service to manage an TEntity
    /// </summary>
    public class FaLeistungService : ServiceCRUDBase<FaLeistung>
    {
        #region Constructors

        protected FaLeistungService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public override FaLeistung GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repository = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);

            var returnValue = repository
                .Where(faLeistung => faLeistung.FaLeistungID == id)
                .SingleOrDefault();

            if (returnValue == null)
            {
                throw new EntityNotFoundException("no entity of 'FaLeistung' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        public FaLeistung GetFaLeistungById(IUnitOfWork unitOfWork, int faLeistungId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var leistungen = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);

            var leistung = leistungen
                            .Include(x => x.BaPerson)
                            .Include(x => x.XUser)
                            .Include(x => x.XUser_Sachbearbeiter)
                            .Where(x => x.FaLeistungID == faLeistungId)
                            .FirstOrDefault();

            if (leistung != null)
            {
                SetEntityValidator(leistung);
                unitOfWork.StartTrackingAndMarkAsUnchangedAll();
            }

            return leistung;
        }

        public FaLeistung GetFaLeistungFallfuehrung(IUnitOfWork unitOfWork, int baPersonId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var leistungen = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);

            var leistung = leistungen
                            .Where(x => x.BaPersonID == baPersonId)
                            .Where(x => x.ModulID == 2) //2: Fallfuehrung
                            .OrderByDescending(x => x.DatumVon)
                            .FirstOrDefault();
            return leistung;
        }

        public bool IsUserFallfuehrer(IUnitOfWork unitOfWork, int userId, int baPersonId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var leistungRepository = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);
            return leistungRepository
                .Any(
                    x => x.BaPersonID == baPersonId
                         && x.ModulID == 2
                         && x.UserID == userId
                         && (!x.DatumBis.HasValue || x.DatumBis.Value >= DateTime.Today)
                );
        }

        public override KissServiceResult ValidateInMemory(FaLeistung dataToValidate)
        {
            // validation: check if entity is consistent in itself
            var serviceResult = FaLeistungValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        #endregion

        #endregion
    }
}