using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Kiss4Web.Infrastructure.Authentication;
using Kiss4Web.Infrastructure.DataAccess;

namespace Kiss4Web.IdentityServer
{
    public class Kiss4ProfileService : IProfileService
    {
        private readonly ConnectionString _connectionString;

        public Kiss4ProfileService(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var userId = int.Parse(context.Subject.Identity.GetSubjectId());
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT UserId, LogonName, FirstName, LastName, ShortName, IsUserAdmin, IsUserBIAGAdmin FROM dbo.XUser WHERE UserId = @userId";
                cmd.Parameters.AddWithValue("userId", userId);
                var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    var user = new
                    {
                        Id = reader.GetInt32(0),
                        LogonName = reader["LogonName"] as string,
                        FirstName = reader["FirstName"] as string,
                        LastName = reader["LastName"] as string,
                        ShortName = reader["ShortName"] as string,
                        IsUserAdmin = (bool)reader["IsUserAdmin"],
                        IsUserSuperAdmin = (bool)reader["IsUserBIAGAdmin"]
                    };
                    context.IssuedClaims.Add(new Claim(Kiss4WebClaims.Name, $"{user.FirstName ?? string.Empty} {user.LastName ?? string.Empty}"));
                    if (!string.IsNullOrEmpty(user.ShortName))
                    {
                        context.IssuedClaims.Add(new Claim(Kiss4WebClaims.ShortName, user.ShortName));
                    }

                    if (!string.IsNullOrEmpty(user.LogonName))
                    {
                        context.IssuedClaims.Add(new Claim(Kiss4WebClaims.LogonName, user.LogonName));
                    }

                    if (user.IsUserAdmin)
                    {
                        context.IssuedClaims.Add(new Claim(Kiss4WebClaims.IsUserAdmin, bool.TrueString));
                    }
                    if (user.IsUserSuperAdmin)
                    {
                        context.IssuedClaims.Add(new Claim(Kiss4WebClaims.IsUserSuperAdmin, bool.TrueString));
                    }

                    context.IssuedClaims.Add(new Claim(Kiss4WebClaims.UserId, user.Id.ToString()));


                }
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var userId = int.Parse(context.Subject.Identity.GetSubjectId());
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT IsLocked FROM dbo.XUser WHERE UserId = @userId";
                cmd.Parameters.AddWithValue("userId", userId);
                var isLocked = await cmd.ExecuteScalarAsync();
                context.IsActive = (isLocked as bool?) == false;
            }
        }
    }
}