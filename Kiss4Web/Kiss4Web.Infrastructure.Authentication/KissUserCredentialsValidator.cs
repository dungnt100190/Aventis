using System.Security.Claims;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Kiss4Web.Model;
using Microsoft.EntityFrameworkCore;

namespace Kiss4Web.Infrastructure.Authentication
{
    public class KissUserCredentialsValidator : ICredentialsValidator
    {
        private readonly IRepository<XUser> _users;

        public KissUserCredentialsValidator(IRepository<XUser> users)
        {
            _users = users;
        }

        public async Task<ClaimsIdentity> ValidateCredentials(string userName, string password)
        {
            ClaimsIdentity identity = null;
            var user = await _users.FirstOrDefaultAsync(usr => usr.LogonName == userName);
            if (user != null)
            {
                var passwordHash = user.PasswordHash;
                if (ScramblePassword(password) == passwordHash)
                {
                    identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userName), new Claim(Kiss4WebClaims.UserId, user.Id.ToString()) });
                }
            }

            return identity;
        }

        private static string ScramblePassword(string password)
        {
            return new Scrambler("KiSS4").EncryptString(password ?? "");
        }
    }
}