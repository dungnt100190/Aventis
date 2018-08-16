using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace Kiss4Web.IdentityServer
{
    public class AuthenticationConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "webclient.ro",

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    //// secret for authentication
                    ClientSecrets =
                    {
                        new Secret("EA59A39A-B03D-4985-A4FA-9297663A1858".Sha256())
                    },

                    //AllowOfflineAccess = true,

                    // scopes that client has access to
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        "api"
                    },
					//AllowedCorsOrigins = new List<string>{"http://localhost:4300"}
                    AllowedCorsOrigins = new List<string>{
                        "http://192.168.35.140:4300",
                        "http://192.168.35.140:8001",
                        "http://192.168.35.140:8001/api",
                        "http://localhost:4300",
                        "http://localhost:8001/api"
                    }
                }
            };
        }
    }
}