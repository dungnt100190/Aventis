using System.Collections.Generic;
using System.Linq;

using Kiss.DbContext;

namespace Kiss.DataAccess.Kes
{
    public class KesArtikelRepository : Repository<KesArtikel>
    {
        /// <summary>
        /// Only for testing purpose
        /// </summary>
        public KesArtikelRepository()
        {
        }

        public KesArtikelRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public virtual IList<KesArtikel> GetArtikelOfKs(bool isKs)
        {
            var code = isKs ? 2 : 1;
            return DbSet
                .Where(art => art.KesMassnahmeTypCode == code)
                .OrderBy(art => art.Artikel)
                .ThenBy(art => art.Absatz)
                .ThenBy(art => art.Ziffer)
                .ThenBy(art => art.Gesetz)
                .ToList();
        }

        public virtual IList<KesArtikel> GetByArtikelIds(int[] artikel)
        {
            return artikel
                .Select(i => DbSet.FirstOrDefault(kar => kar.KesArtikelID == i))
                .Where(art => art != null)
                .OrderBy(art => art.Artikel)
                .ThenBy(art => art.Absatz)
                .ThenBy(art => art.Ziffer)
                .ThenBy(art => art.Gesetz)
                .ToList();
        }
    }
}