using System.Linq;
using Kiss.DbContext;

namespace Kiss.DataAccess.Fa
{
    public class FaLeistungZugriffRepository : Repository<FaLeistungZugriff>
    {
        public FaLeistungZugriffRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public FaLeistungZugriff GetByFaLeistungAndUser(int faLeistungId, int userId)
        {
            return DbSet.FirstOrDefault(lez => lez.FaLeistungID == faLeistungId && 
                                               lez.UserID == userId);
        }
    }
}
