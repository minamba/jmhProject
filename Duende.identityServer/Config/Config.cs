using Duende.IdentityServer.Models;

namespace Duende.Server.Config
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new []
            {
            //OpenId et Profile représente le standard des scopes d'open id connect que nous voulons que le serveur identity suppporte
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource
            {
                Name = "role",
                UserClaims = new List<string> {"role"}
            }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
            new ApiScope("jmh.api.read"),
             new ApiScope("jmh.api.write")
            };

        public static IEnumerable<ApiResource> ApiResource => new[]
        {
            new ApiResource("Quizz.jmh.api")
            {
                Scopes = new List<string> {"jmh.api.read", "jmh.api.write"},
                ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
                UserClaims = new List<string> {"role"}
            }
        };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
            // m2m client credentials flow client m2m = machine to machine
            new Client
            {
                ClientId = "m2m.client",
                ClientName = "m2m",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                AllowedScopes = { "jmh.api.read" }
            },

             //interactive client using code flow + pkce
            new Client
            {
                ClientId = "interactive",
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:44300/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "scope2" }
            },
            };
    }
}
