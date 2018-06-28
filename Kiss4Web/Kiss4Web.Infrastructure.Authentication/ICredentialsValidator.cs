using System.Security.Claims;
using System.Threading.Tasks;

namespace Kiss4Web.Infrastructure.Authentication
{
    public interface ICredentialsValidator
    {
        Task<ClaimsIdentity> ValidateCredentials(string userName, string password);
    }
}