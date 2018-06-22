using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4.Models;

namespace Server
{
    public class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client> {
                new Client {
                    ClientId = "clientId",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {
                        new Secret ("secret".Sha256 ())
                        },
                        Claims = {
                        new Claim ("name", "名称")
                        },
                        AllowedScopes = { "api1" }
                    },
            };
        }
    }
}