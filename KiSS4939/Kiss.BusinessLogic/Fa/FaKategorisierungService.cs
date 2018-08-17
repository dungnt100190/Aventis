using System;
using System.Collections.ObjectModel;
using System.Linq;
using Kiss.DataAccess;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.DbContext.Constant;
using Kiss.Interfaces.BL;
using IUnitOfWork = Kiss.Interfaces.BL.IUnitOfWork;

namespace Kiss.BusinessLogic.Fa
{
    public class FaKategorisierungService : ServiceCRUD<FaKategorisierung>
    {
        public ObservableCollection<FaKategorisierung> GetByBaPersonId(int baPersonId)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return new ObservableCollection<FaKategorisierung>(unitOfWork.FaKategorisierung.GetByBaPersonId(baPersonId));
            }
        }


        //public override KissServiceResult ValidateOnDatabase(IUnitOfWork unitOfWork, FaKategorisierung dataToValidate)
        //{
        //    var result = base.ValidateOnDatabase(unitOfWork, dataToValidate);
        //    var repo = UnitOfWork.GetRepository<FaKategorisierung>(unitOfWork);
        //    var isNew = dataToValidate.ChangeTracker.State == ObjectState.Added;

        //    var temp = repo.FirstOrDefault(
        //        k => k.BaPersonID == dataToValidate.BaPersonID
        //             && dataToValidate.FaKategorisierungID != k.FaKategorisierungID
        //             && dataToValidate.Datum <= (k.Abschlussdatum ?? (isNew ? k.Datum : DateTime.MaxValue))
        //             && (dataToValidate.Abschlussdatum ?? DateTime.MaxValue) >= k.Datum
        //             );

        //    if (temp != null)
        //    {
        //        result += KissServiceResult.Error("FaKategorisierung_Ueberlappung", "Es gibt Kategorien, die sich überschneiden. Es darf immer nur eine gültige Kategorie geben.");
        //    }

        //    return result;
        //}
    }
}
