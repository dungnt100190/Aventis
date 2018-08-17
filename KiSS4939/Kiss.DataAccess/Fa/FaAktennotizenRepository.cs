using System.Data.Entity;
using System.Linq;
using Kiss.DbContext;

namespace Kiss.DataAccess.Fa
{
    public class FaAktennotizenRepository : Repository<FaAktennotizen>
    {
        public FaAktennotizenRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public FaAktennotizen[] GetAktennotizen(int[] faLeistungIDs)
        {
            return DbSet
                   .Where(akn => faLeistungIDs.Contains(akn.FaLeistungID) &&
                                 akn.Datum.HasValue &&
                                 !akn.IsDeleted)
                   .Include(akn => akn.XUser)
                   .ToArray();
        }
    }
}
