using IdentityModel.Client;
using Quizz.jmh.Domain.Interfaces.Repositories;
using Quizz.jmh.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Domain.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;


        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<TokenResponse> GetToken(string scope)
        {
            return await _tokenRepository.GetToken(scope);
        }
    }
}
