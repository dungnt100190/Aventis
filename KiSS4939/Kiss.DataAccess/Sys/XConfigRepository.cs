using System;
using System.Linq;
using Kiss.DbContext;

namespace Kiss.DataAccess.Sys
{
    public class XConfigRepository : Repository<XConfig>
    {
        public XConfigRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        // nur für UnitTesting
        protected XConfigRepository()
        {
        }

        public XConfig GetByKeyPath(string keyPath, DateTime validAt)
        {
            return DbSet
                   .Where(cfg => cfg.KeyPath == keyPath && cfg.DatumVon < validAt)
                   .OrderBy(cfg => cfg.DatumVon)
                   .FirstOrDefault();
        }
    }
}
