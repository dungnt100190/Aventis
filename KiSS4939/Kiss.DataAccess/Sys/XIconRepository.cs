using Kiss.DbContext;

namespace Kiss.DataAccess.Sys
{
    public class XIconRepository : Repository<XIcon>
    {
        #region Constructors

        public XIconRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public XIconRepository()
        {
        }

        #endregion
    }
}