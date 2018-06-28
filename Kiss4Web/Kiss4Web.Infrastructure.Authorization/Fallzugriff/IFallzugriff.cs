using System.Threading.Tasks;
using Kiss4Web.Model.QueryTypes;

namespace Kiss4Web.Infrastructure.Authorization.Fallzugriff
{
    public interface IFallzugriff
    {
        Task<FallZugriffItem> GetFallRights(int faLeistungId);
    }
}