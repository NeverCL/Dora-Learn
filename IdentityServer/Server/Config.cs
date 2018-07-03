using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Server {
    public class Config {

        /// <summary>
        /// Identity Resources
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles",new []{ClaimTypes.Role,"role"})
            };
        }

        /// <summary>
        /// Api Resources
        /// </summary>
        /// <returns></returns>
        public static List<ApiResource> GetApiResources () {
            return new List<ApiResource> () {
                new ApiResource("api1","apiDisplayName")   // apiId 不仅仅作为 apiName ，同时也添加到 Scopes
            };
        }

        /// <summary>
        /// Clients
        /// </summary>
        /// <returns></returns>
        public static List<Client> GetClients () {
            return new List<Client> () {
                new Client {
                    ClientId = "clientId", // Require
                    RequireConsent = false,
                    ClientSecrets = new [] { new Secret ("secret".Sha512 ()) },
                    AllowedGrantTypes = GrantTypes.Implicit, // Require
                    AllowedScopes = new [] { "roles","openid","profile" },  // openid 和 profile 是 OpenID 定义的标准资源
                    RedirectUris = {"http://localhost:6001/signin-oidc","http://localhost:6002/signin-oidc"}       // OpenID 会校验客户端参数，通常为 http://api/signin-oidc
                },// JavaScript Client
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,

                    RedirectUris =           { "http://localhost:6002/callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:6002/index.html" },
                    AllowedCorsOrigins =     { "http://localhost:6002" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    }
                }
            };
        }

        /// <summary>
        /// Users
        /// </summary>
        /// <returns></returns>
        public static List<TestUser> GetUsers(){
            return new List<TestUser>{
                new TestUser {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password",
                    Claims = new []
                    {
                        new Claim("name", "Alice"),
                        new Claim("website", "https://alice.com"),
                        new Claim(ClaimTypes.Role, "admin"),
                        new Claim(ClaimTypes.Role, "admin2"),
                        new Claim("role", "admin3")
                    }
                }
            };
        }

    }
}