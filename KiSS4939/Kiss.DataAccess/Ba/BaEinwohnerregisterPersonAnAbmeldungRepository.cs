using Kiss.DbContext;

namespace Kiss.DataAccess.Ba
{
    public class BaEinwohnerregisterPersonAnAbmeldungRepository : Repository<BaEinwohnerregisterPersonAnAbmeldung>
    {
        public BaEinwohnerregisterPersonAnAbmeldungRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}