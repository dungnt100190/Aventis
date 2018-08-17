using System.Collections.Generic;
using System.Linq;
using Kiss.DbContext;

namespace Kiss.DataAccess.Sys
{
    public class XLangTextRepository : Repository<XLangText>
    {
        public XLangTextRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        // nur für UnitTesting
        protected XLangTextRepository()
        {
        }

        public override XLangText Remove(XLangText entityToDelete)
        {
            // make sure the entity is in the context
            entityToDelete = DbSet.Find(entityToDelete.TID, entityToDelete.LanguageCode);

            CheckIfDbIsStillConsistentAfterDelete(entityToDelete);
            return DbSet.Remove(entityToDelete);
        }
    }
}