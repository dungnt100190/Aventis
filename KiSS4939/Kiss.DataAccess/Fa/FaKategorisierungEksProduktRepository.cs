using System.Collections.Generic;
using System.Linq;
using Kiss.DataAccess.Validation;
using Kiss.DbContext;

namespace Kiss.DataAccess.Fa
{
    public class FaKategorisierungEksProduktRepository : Repository<FaKategorisierungEksProdukt>
    {
        public FaKategorisierungEksProduktRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public IList<FaKategorisierungEksProdukt> GetByOrgUnitIDs(int[] orgUnitIDs)
        {
            return DbSet
                   .Where(kep => orgUnitIDs.Contains(kep.OrgUnitID))
                   .ToList();
        }
    }
}
