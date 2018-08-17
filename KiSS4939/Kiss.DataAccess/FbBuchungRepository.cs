using System;
using System.Collections.Generic;
using System.Linq;
using Kiss.DbContext;

namespace Kiss.DataAccess
{
    public class FbBuchungRepository : Repository<FbBuchung>
    {
        public FbBuchungRepository(IDbContext dbContext)
            : base(dbContext)
        {

        }

        public decimal GetSollBetrag(int fbPeriodeId, DateTime maxBuchungsDatum, IEnumerable<int> kontoNr)
        {
            return (from buc in DbSet
                    where buc.FbPeriodeID == fbPeriodeId
                       && buc.BuchungsDatum <= maxBuchungsDatum
                       && buc.SollKtoNr.HasValue
                       && kontoNr.Contains((int)buc.SollKtoNr)
                    select (decimal?)buc.Betrag)
                   .Sum() ?? 0m;
        }

        public decimal GetHabenBetrag(int fbPeriodeId, DateTime maxBuchungsDatum, IEnumerable<int> kontoNr)
        {
            return (from buc in DbSet
                    where buc.FbPeriodeID == fbPeriodeId
                       && buc.BuchungsDatum <= maxBuchungsDatum
                       && buc.HabenKtoNr.HasValue
                       && kontoNr.Contains((int)buc.HabenKtoNr)
                    select (decimal?)buc.Betrag)
                   .Sum() ?? 0m;
        }
    }
}
