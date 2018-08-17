using System.Linq;
using Kiss.DbContext;

namespace Kiss.DataAccess
{
    public class BaGesundheitRepository : Repository<BaGesundheit>
    {
        public BaGesundheitRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public BaGesundheit GetGesundheit(int baPersonID)
        {
            return (from ges in DbSet
                    where ges.BaPerson.BaPersonID == baPersonID
                    orderby ges.DatumVon descending
                    select ges).SingleOrDefault();
        }
    }
}
