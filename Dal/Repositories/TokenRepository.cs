using IdentityModel.Client;
using Microsoft.Extensions.Options;
using Quizz.jmh.Domain.Interfaces.Repositories;
using Quizz.jmh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Dal.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IOptions<DuendeIdentityServer> _duendeIdentityServer;
        private readonly DiscoveryDocumentResponse _discoveryDocumentResponse;

        public TokenRepository(IOptions<DuendeIdentityServer> duendeIdentityServer)
        {
            _duendeIdentityServer = duendeIdentityServer;

            using var httpClient = new HttpClient();
            _discoveryDocumentResponse = httpClient.GetDiscoveryDocumentAsync(duendeIdentityServer.Value.DiscoveryUrl).Result;
            if(_discoveryDocumentResponse.IsError)
            {
                throw new Exception("Unable to get discovery document", _discoveryDocumentResponse.Exception);
            }
        }

        public async Task<TokenResponse> GetToken(string scope)
        {
            using var client = new HttpClient();
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
               Address = _discoveryDocumentResponse.TokenEndpoint,
               ClientId = _duendeIdentityServer.Value.ClientId,
               ClientSecret = _duendeIdentityServer.Value.ClientPassword,
               Scope = scope
            });

            if(tokenResponse.IsError)
            {
                throw new Exception("Unable to get token", tokenResponse.Exception);
            }

            return tokenResponse;
        }
    }
}
