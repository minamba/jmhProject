using OpenIddict.Abstractions;
using OpenIddict.Core;
using Quizz.jmh.Domain.Interfaces.Repositories;
using Quizz.jmh.Domain.Interfaces.Services;
using Quizz.jmh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Domain.Services
{
    public class ClientApplicationService : IClientApplicationService
    {
        private readonly IClientApplicationRepository _clientApplicationRepository;
        //private readonly OpenIddictApplicationManager<OpenIddictApplication> _openIddictApplicationManager;

        public ClientApplicationService(IClientApplicationRepository clientApplicationRepository/*, OpenIddictApplicationManager<OpenIddictApplication> openIddictApplicationManager*/)
        {
            _clientApplicationRepository = clientApplicationRepository;
            //_openIddictApplicationManager = openIddictApplicationManager;
        }

        public async Task CreateApplicationClient() => await _clientApplicationRepository.CreateApplicationClient();
    }
}
