using System.Collections.Generic;
using System.Linq;

using Kiss.DbContext;

namespace Kiss.DataAccess.Kes
{
    public class KesMassnahmeArtikelRepository : Repository<KesMassnahme_KesArtikel>
    {
        /// <summary>
        /// Only for testing purpose
        /// </summary>
        public KesMassnahmeArtikelRepository()
        {
        }

        public KesMassnahmeArtikelRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public IList<KesMassnahme_KesArtikel> GetArtikelByMassnahmeId(int massnahmeId)
        {
            return DbSet.Where(kmka => kmka.KesMassnahmeID == massnahmeId).ToList();
        }

        public void RemoveByKesMassnahmeID(int massnahmeId)
        {
            var artikelToDelete = DbSet
                .Where(x => x.KesMassnahmeID == massnahmeId)
                .ToList();

            artikelToDelete.ForEach(x => DbSet.Remove(x));
        }
    }
}