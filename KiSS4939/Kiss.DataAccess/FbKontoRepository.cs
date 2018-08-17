using System.Collections.Generic;
using System.Linq;
using Kiss.DbContext;

namespace Kiss.DataAccess
{
    public class FbKontoRepository : Repository<FbKonto>
    {
        public FbKontoRepository(IDbContext dbContext)
            : base(dbContext)
        {

        }

        public IEnumerable<FbKonto> GetKontoBySaldoGruppe(int fbPeriodeId, string saldoGruppeName)
        {
            return from kto in DbSet
                   where kto.FbPeriodeID == fbPeriodeId
                         && kto.SaldoGruppeName == saldoGruppeName
                   select kto;
        }
    }
}
