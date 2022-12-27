using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using IdentityModel;
using System.Security.Claims;

namespace IdentityServer.Configuration
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "JmhClient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "JmhApi" }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("JmhApi", "J'aime mon histoire API")
        };

        public static IEnumerable<IdentityResource> ApiResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
        };

        public static List<TestUser> TestUsers =>
        new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "db3be572-980d-4594-bc32-07275ab6ae4b",
                Username = "mehmet",
                Password =   "mehmet",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.GivenName, "mehmet"),
                    new Claim(JwtClaimTypes.GivenName, "ozkaya")
                }
            }
        };

    }
}
