using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Authentication.UserId;
using Kiss4Web.Model.QueryTypes;

namespace Kiss4Web.Infrastructure.Authorization.Fallzugriff
{
    public class Fallzugriff : IFallzugriff
    {
        private readonly IQueryable<FallZugriffItem> _fallzugriffe;
        private readonly AuthenticatedUserId _userId;

        public Fallzugriff(IQueryable<FallZugriffItem> fallzugriffe, AuthenticatedUserId userId)
        {
            _fallzugriffe = fallzugriffe;
            _userId = userId;
        }

        public Task<FallZugriffItem> GetFallRights(int faLeistungId)
        {
            return Task.FromResult(new FallZugriffItem
            {
                MayRead = true,
                MayInsert = true,
                MayUpdate = true,
                MayDelete = true
            });
            // ToDo with ef core 2.1
            /*_fallzugriffe.AsNoTracking()
                                .FromSql("EXEC dbo.spFaGetFallZugriff {0}, {1}", _userId, faLeistungId)
                                .FirstOrDefaultAsync();*/
        }
    }
}