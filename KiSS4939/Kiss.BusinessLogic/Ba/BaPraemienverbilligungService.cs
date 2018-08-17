using System.Collections.Generic;

using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;

namespace Kiss.BusinessLogic.Ba
{
    public class BaPraemienverbilligungService : ServiceCRUD<BaPraemienverbilligung>
    {
        public virtual List<BaPraemienverbilligung> GetByBapersonId(int bapersonId)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.BaPraemienverbilligung.GetByBaPersonId(bapersonId);
            }
        }

        public virtual BaPraemienverbilligung GetByBapersonIdJahrFolgenummer(int bapersonId, int jahr, int folgenummer)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.BaPraemienverbilligung.GetByBaPersonIdJahrFolgenummer(bapersonId, jahr, folgenummer);
            }
        }
    }
}