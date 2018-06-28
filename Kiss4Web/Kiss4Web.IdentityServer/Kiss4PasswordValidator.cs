using System.Data.SqlClient;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Kiss4Web.Infrastructure.Authentication;
using Kiss4Web.Infrastructure.DataAccess;

namespace Kiss4Web.IdentityServer
{
    public class Kiss4PasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly ConnectionString _connectionString;
        private readonly Scrambler _scrambler;

        public Kiss4PasswordValidator(ConnectionString connectionString, Scrambler scrambler)
        {
            _connectionString = connectionString;
            _scrambler = scrambler;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT UserId, PasswordHash FROM dbo.XUser WHERE LogonName = @logonName";
                cmd.Parameters.AddWithValue("logonName", context.UserName);

                var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var user = new
                    {
                        Id = reader.GetInt32(0),
                        PasswordHash = reader.GetString(1),
                    };

                    var scrambledPasswordToCheck = _scrambler.EncryptString(context.Password);
                    if (scrambledPasswordToCheck == user.PasswordHash)
                    {
                        //var nameClaim = new Claim(Kiss4WebClaims.Name, $"{user.FirstName} {user.LastName}");
                        //var shortNameClaim = new Claim(Kiss4WebClaims.ShortName, user.LogonName);
                        //var logonNameClaim = new Claim(Kiss4WebClaims.LogonName, user.LogonName);
                        context.Result = new GrantValidationResult(user.Id.ToString(), "custom");
                    }
                    else
                    {
                        context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Username/Passwort ungültig");
                    }
                }
            }
        }
    }
}