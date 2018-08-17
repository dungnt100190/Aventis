using Kiss.DbContext;

namespace Kiss.DataAccess.Ba
{
    public class BaEinwohnerregisterEmpfangeneEreignisseRepository : Repository<BaEinwohnerregisterEmpfangeneEreignisse>
    {
        public BaEinwohnerregisterEmpfangeneEreignisseRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}