using System;
using System.Linq;
using Kiss.DbContext;

namespace Kiss.DataAccess.Ba
{
    public class BaPlzRepository : Repository<BaPLZ>
    {
        public BaPlzRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public BaPLZ[] GetPlzValidAt(DateTime validAt)
        {
            return DbSet
                   .Where(plz => (plz.DatumVon == null || plz.DatumVon <= validAt) && 
                                 (plz.DatumBis == null || plz.DatumBis >= validAt))
                   .OrderBy(gem=>gem.Name)
                   .ToArray();
        }
    }
}
