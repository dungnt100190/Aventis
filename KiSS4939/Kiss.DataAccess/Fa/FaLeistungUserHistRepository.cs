using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Kiss.DbContext;

namespace Kiss.DataAccess.Fa
{
    public class FaLeistungUserHistRepository : Repository<FaLeistungUserHist>
    {
        public FaLeistungUserHistRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public IList<FaLeistungUserHist> GetFalluebergaben(int[] faLeistungIDs)
        {
            return DbSet
                   .Where(luh => faLeistungIDs.Contains(luh.FaLeistungID))
                   .OrderByDescending(luh => luh.DatumVon)
                   .Include(luh => luh.XUser)
                   .ToList();
        }
    }
}
