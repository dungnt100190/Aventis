using System;
using System.Linq;
using Kiss.DbContext;

namespace Kiss.DataAccess
{
    public class FbPeriodeRepository : Repository<FbPeriode>
    {
        public FbPeriodeRepository(IDbContext dbContext)
            : base(dbContext)
        {

        }

        public FbPeriode GetCurrentPeriode(int baPersonID)
        {
            var date = DateTime.Today;
            var periode = (from prd in DbSet
                           where prd.BaPersonID == baPersonID
                              && prd.PeriodeVon <= date
                              && prd.PeriodeBis >= date
                           orderby prd.PeriodeVon descending
                           select prd).SingleOrDefault();

            return periode;
        }
    }
}
