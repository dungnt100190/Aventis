using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;

namespace Kiss.BusinessLogic.Kes
{
    public class KesMassnahmeArtikelService : ServiceCRUD<KesMassnahme_KesArtikel>
    {
        private KesMassnahmeArtikelService()
        {
        }

        public void DeleteByKesMassnahmeId(int kesMassnahmeID)
        {
            using (var unitOfWork = CreateNewUnitOfWork<IKissUnitOfWork>())
            {
                var artikelToDelete = unitOfWork.KesMassnahmeArtikel.GetArtikelByMassnahmeId(kesMassnahmeID);

                foreach (var artikel in artikelToDelete)
                {
                    DeleteEntity(artikel);
                }
            }
        }
    }
}