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
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:7025/");
            if (! disco.IsError)
            {
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,

                    ClientId = "JmhClient",
                    ClientSecret = "secret",
                    Scope = "JmhApi"
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
