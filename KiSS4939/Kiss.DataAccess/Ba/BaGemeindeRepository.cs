using System;
using System.Linq;
using Kiss.DbContext;

namespace Kiss.DataAccess.Ba
{
    public class BaGemeindeRepository : Repository<BaGemeinde>
    {
        public BaGemeindeRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public int? GetBaGemeindeIdByBfsCode(int bfsCode)
        {
            return GetGemeindenValidAtQueryable(DateTime.Now)
                .Where(x => x.BFSCode == bfsCode)
                .Select(x => x.BaGemeindeID)
                .Cast<int?>()
                .FirstOrDefault();
        }

        public int? GetBaGemeindeIdByKantonAndName(string kanton, string name)
        {
            return GetGemeindenValidAtQueryable(DateTime.Now)
                .Where(x => x.Kanton == kanton)
                .Where(x => x.Name == name)
                .Select(x => x.BaGemeindeID)
                .Cast<int?>()
                .FirstOrDefault();
        }

        public BaGemeinde[] GetGemeindenValidAt(DateTime validAt)
        {
            return GetGemeindenValidAtQueryable(validAt)
                .OrderBy(gem => gem.Name)
                .ToArray();
        }

        private IQueryable<BaGemeinde> GetGemeindenValidAtQueryable(DateTime validAt)
        {
            return DbSet.Where(gem => (gem.GemeindeAufnahmeDatum == null || gem.GemeindeAufnahmeDatum <= validAt) &&
                                      (gem.GemeindeAufhebungDatum == null || gem.GemeindeAufhebungDatum >= validAt));
        }
    }
}