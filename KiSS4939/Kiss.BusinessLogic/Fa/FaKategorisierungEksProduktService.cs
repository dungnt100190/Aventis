using System.Collections.Generic;
using System.Linq;
using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

namespace Kiss.BusinessLogic.Fa
{
    public class FaKategorisierungEksProduktService : ServiceCRUD<FaKategorisierungEksProdukt>
    {
        public IList<FaKategorisierungEksProdukt> GetProdukteForCurrentUser(bool includeNullValue)
        {
            var sessionService = Container.Resolve<ISessionService>();
            var userId = sessionService.AuthenticatedUser.UserID;

            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                var orgHierarchyList = unitOfWork.XOrgUnit.GetHierarchyListOfUser(userId);
                if (orgHierarchyList == null || orgHierarchyList.Count == 0)
                {
                    return new List<FaKategorisierungEksProdukt>();
                }
                var produkte = unitOfWork.FaKategorisierungEksProdukt.GetByOrgUnitIDs(orgHierarchyList.Select(org => org.OrgUnitID).ToArray());
                if (includeNullValue)
                {
                    produkte.Insert(0, new FaKategorisierungEksProdukt
                                           {
                                               FaKategorisierungEksProduktID = -1,
                                               Text = string.Empty,
                                               ShortText = string.Empty
                                           });
                }
                return produkte;
            }
        }
    }
}
