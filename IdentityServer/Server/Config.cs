using System.Collections.Generic;
using IdentityServer4.Models;

namespace Server {
    public class Config {
        public static List<Client> GetClients() {
            return new List<Client>() {
                new Client {
                    ClientId = "clientId",                                  // Require
                    AllowedGrantTypes = GrantTypes.ClientCredentials,       // Require
                    AllowedScopes = new [] { "apiId" },
                    ClientName = "clientName",
                    ClientSecrets = new [] { new Secret ("secret".Sha512 ()) },
                }
            };
        }
        

        public static List<ApiResource> GetApiResources(){
            return new List<ApiResource>() {
                new ApiResource{
                    Name = "apiId",                                         // Require
                    DisplayName = "apiDisplayName",
                }
            };
        }
    }
}