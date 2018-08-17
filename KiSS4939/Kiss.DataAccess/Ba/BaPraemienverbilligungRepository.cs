using System.Collections.Generic;
using System.Linq;

using Kiss.DbContext;

namespace Kiss.DataAccess.Ba
{
    public class BaPraemienverbilligungRepository : Repository<BaPraemienverbilligung>
    {
        public BaPraemienverbilligungRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public List<BaPraemienverbilligung> GetByBaPersonId(int baPersonId)
        {
            return DbSet
                .Where(ipv => ipv.BaPersonID == baPersonId)
                .ToList();
        }

        public BaPraemienverbilligung GetByBaPersonIdJahrFolgenummer(int baPersonId, int jahr, int folgenummer)
        {
            return DbSet.SingleOrDefault(ipv => ipv.BaPersonID == baPersonId && ipv.Jahr == jahr && ipv.Folgenummer == folgenummer);
        }
    }
}