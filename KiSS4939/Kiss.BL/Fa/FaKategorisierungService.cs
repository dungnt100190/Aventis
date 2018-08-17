using System;
using System.Collections.ObjectModel;
using System.Linq;

using Kiss.BL.Fa.Validation;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Model;

using KiSS.Common.Exceptions;

namespace Kiss.BL.Fa
{
    /// <summary>
    /// Service to manage a FaKategorisierung.
    /// </summary>
    public class FaKategorisierungService : ServiceCRUDBase<FaKategorisierung>
    {
        #region Constructors

        private FaKategorisierungService()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public ObservableCollection<FaKategorisierung> GetByBaPersonId(IUnitOfWork unitOfWork, int baPersonId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repo = UnitOfWork.GetRepository<FaKategorisierung>(unitOfWork);

            var result = repo
                .Where(x => x.BaPersonID == baPersonId)
                .OrderByDescending(x => x.Datum);

            foreach (var kategorie in result)
            {
                SetEntityValidator(kategorie);
                kategorie.StartTracking();
            }

            return new ObservableCollection<FaKategorisierung>(result);
        }

        public override FaKategorisierung GetById(IUnitOfWork unitOfWork, int id)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var repo = UnitOfWork.GetRepository<FaKategorisierung>(unitOfWork);

            var returnValue = repo.SingleOrDefault(x => x.FaKategorisierungID == id);

            if (returnValue == null)
            {
                throw new EntityNotFoundException("No entity of 'FaKategorisierung' found with id: " + id);
            }

            SetEntityValidator(returnValue);
            unitOfWork.StartTrackingAndMarkAsUnchangedAll();

            return returnValue;
        }

        public override KissServiceResult NewData(out FaKategorisierung newData)
        {
            var result = base.NewData(out newData);

            if (result)
            {
                var sessionService = Container.Resolve<ISessionService>();
                newData.UserID = sessionService.AuthenticatedUser.UserID;
            }

            return result;
        }

        public override KissServiceResult ValidateInMemory(FaKategorisierung dataToValidate)
        {
            var serviceResult = FaKategorisierungValidator.ValidateEntity(dataToValidate);

            return serviceResult + base.ValidateInMemory(dataToValidate);
        }

        public override KissServiceResult ValidateOnDatabase(IUnitOfWork unitOfWork, FaKategorisierung dataToValidate)
        {
            var result = base.ValidateOnDatabase(unitOfWork, dataToValidate);
            var repo = UnitOfWork.GetRepository<FaKategorisierung>(unitOfWork);
            var isNew = dataToValidate.ChangeTracker.State == ObjectState.Added;

            var temp = repo.FirstOrDefault(
                k => k.BaPersonID == dataToValidate.BaPersonID
                     && dataToValidate.FaKategorisierungID != k.FaKategorisierungID
                     && dataToValidate.Datum <= (k.Abschlussdatum ?? (isNew ? k.Datum : DateTime.MaxValue))
                     && (dataToValidate.Abschlussdatum ?? DateTime.MaxValue) >= k.Datum
                     );

            if (temp != null)
            {
                result += KissServiceResult.Error("FaKategorisierung_Ueberlappung", "Es gibt Kategorien, die sich überschneiden. Es darf immer nur eine gültige Kategorie geben.");
            }

            return result;
        }

        #endregion

        #endregion
    }
}