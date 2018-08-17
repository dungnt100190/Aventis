using System.Collections.Generic;
using System.Linq;

using Kiss.DbContext;
using Kiss.DbContext.Constant;

namespace Kiss.DataAccess.Ba
{
    public class BaEinwohnerregisterEmpfangeneEreignisseRohdatenRepository : Repository<BaEinwohnerregisterEmpfangeneEreignisseRohdaten>
    {
        public BaEinwohnerregisterEmpfangeneEreignisseRohdatenRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<BaEinwohnerregisterEmpfangeneEreignisseRohdaten> GetFailedOrPending(int packetSize, bool includeFailedEvents)
        {
            return Filtered(includeFailedEvents).Take(packetSize);
        }

        public int GetFailedOrPendingCount(bool includeFailedEvents)
        {
            return Filtered(includeFailedEvents).Count();
        }

        private IQueryable<BaEinwohnerregisterEmpfangeneEreignisseRohdaten> Filtered(bool includeFailedEvents)
        {
            return DbSet
                .Where(
                    roh =>
                        roh.BaEinwohnerregisterEmpfangeneEreignisseRohdatenStatusCode ==
                        (int)LOVsGenerated.BaEinwohnerregisterEmpfangeneEreignisseRohdatenStatus.Pendent ||
                        (includeFailedEvents && roh.BaEinwohnerregisterEmpfangeneEreignisseRohdatenStatusCode ==
                        (int)LOVsGenerated.BaEinwohnerregisterEmpfangeneEreignisseRohdatenStatus.ImportFehlerhaft));
        }
    }
}