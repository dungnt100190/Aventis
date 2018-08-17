using System.Data.Entity;
using System.Linq;
using Kiss.DbContext;

namespace Kiss.DataAccess.Fa
{
    public class FaPendenzgruppeRepository : Repository<FaPendenzgruppe>
    {
        public FaPendenzgruppeRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

    }
}
