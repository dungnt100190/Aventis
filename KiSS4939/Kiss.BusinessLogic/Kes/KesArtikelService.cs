using System.Collections.Generic;

using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;

namespace Kiss.BusinessLogic.Kes
{
    public class KesArtikelService : ServiceCRUD<KesArtikel>
    {
        private KesArtikelService()
        {
        }

        public virtual IList<KesArtikel> GetKsArtikel(bool isKs)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                return unitOfWork.KesArtikel.GetArtikelOfKs(isKs);
            }
        }
    }
}