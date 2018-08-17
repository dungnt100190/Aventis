using System.Linq;
using Kiss.DbContext;

namespace Kiss.DataAccess.Fa
{
    public class FaLeistungArchivRepository : Repository<FaLeistungArchiv>
    {
        public FaLeistungArchivRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public bool IsLeistungArchiviert(int faLeistungID)
        {
            // Checkout bedeutet, er wurde aus dem Archiv zurückgeholt
            return DbSet.Any(lei => lei.FaLeistungID == faLeistungID
                                 && !lei.CheckOut.HasValue);
        }
    }
}
