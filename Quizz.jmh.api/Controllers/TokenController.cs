using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;

namespace Quizz.jmh.Api.Controllers
{
    [ApiController]
    [Route("Token")]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetToken()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5443/");
            if (! disco.IsError)
            {
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,

                    ClientId = "m2m.client",
                    ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
                    Scope = "jmh.api.read"
                });


                if (!tokenResponse.IsError)                
                    return Ok(tokenResponse.Json);
                else
                    return BadRequest(tokenResponse.IsError.ToString());
            }

            return null;
        }
    }
}
