using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;

namespace Kiss.BusinessLogic.Fa
{
    public class FaLeistungService : ServiceCRUD<FaLeistung>
    {
        public bool IsUserFallfuehrer(int userId, int baPersonId)
        {
            using(var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.FaLeistung.IsUserFallfuehrer(userId, baPersonId, 2);
            }
        }
    }
}
