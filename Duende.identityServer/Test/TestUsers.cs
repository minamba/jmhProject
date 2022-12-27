using Duende.IdentityServer;
using Duende.IdentityServer.Test;
using IdentityModel;
using System.Security.Claims;
using System.Text.Json;

namespace Duende.Server.Test
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = (street_adress : "208 rue des pyramides", locality : "Evry", postal_code : "91000", country : "France");
                
                return new List<TestUser>
                {
                    new TestUser
                    {
                       SubjectId = "1",
                       Username = "minamba",
                       Password = "minamba",
                       Claims =
                        {
                            new Claim(type:JwtClaimTypes.Name, value:"Minamba Camara"),
                            new Claim(type:JwtClaimTypes.Email, value:"minamba@gmail.com"),
                            new Claim(type:JwtClaimTypes.GivenName, value:"Minamba"),
                            new Claim(type:JwtClaimTypes.FamilyName, value:"Camara"),
                            new Claim(type:JwtClaimTypes.EmailVerified, value:"true", valueType:ClaimValueTypes.Boolean),
                            new Claim(type:JwtClaimTypes.WebSite, value:"http://minamba.com"),
                            new Claim(type:JwtClaimTypes.Address, value:JsonSerializer.Serialize(address), valueType:IdentityServerConstants.ClaimValueTypes.Json),
                        }
                    }
                };
            }
        }
    }
}
