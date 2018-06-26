using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Server {
    public class Config {

        /// <summary>
        /// OpenID Resources
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        /// <summary>
        /// OAuth2 Resources
        /// </summary>
        /// <returns></returns>
        public static List<ApiResource> GetApiResources () {
            return new List<ApiResource> () {
                new ApiResource("apiId","apiDisplayName")   // apiId 不仅仅作为 apiName ，同时也添加到 Scopes
            };
        }

        /// <summary>
        /// Client
        /// </summary>
        /// <returns></returns>
        public static List<Client> GetClients () {
            return new List<Client> () {
                new Client {
                    ClientId = "clientId", // Require
                    ClientSecrets = new [] { new Secret ("secret".Sha512 ()) },
                    AllowedGrantTypes = GrantTypes.Implicit, // Require
                    AllowedScopes = new [] { "apiId","openid","profile" },  // openid 和 profile 是 OpenID 定义的标准资源
                    ClientName = "clientName",
                    RedirectUris = {"http://localhost:5001/signin-oidc"}       // OpenID 会校验客户端参数，通常为 http://api/signin-oidc
                }
            };
        }


        public static List<TestUser> GetUsers(){
            return new List<TestUser>{
                new TestUser {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password",
                    Claims = new []
                    {
                        new Claim("name", "Alice"),
                        new Claim("website", "https://alice.com")
                    }
                }
            };
        }



    }
}