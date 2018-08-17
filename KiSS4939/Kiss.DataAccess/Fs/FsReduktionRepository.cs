using System.Collections.Generic;
using System.Linq;
using Kiss.DataAccess.Validation;
using Kiss.DbContext;

namespace Kiss.DataAccess.Fs
{
    public class FsReduktionRepository : Repository<FsReduktion>
    {
        public FsReduktionRepository(IDbContext dbContext)
            : base(dbContext)
        {
            RegisterValidator(new FsReduktionValidator());
        }
    }
}
