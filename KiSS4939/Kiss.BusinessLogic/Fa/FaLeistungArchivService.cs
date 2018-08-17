using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;

namespace Kiss.BusinessLogic.Fa
{
    public class FaLeistungArchivService : ServiceCRUD<FaLeistungArchiv>
    {
        public bool IsLeistungArchiviert(int faLeistungID)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.FaLeistungArchiv.IsLeistungArchiviert(faLeistungID);
            }
        }
    }
}
