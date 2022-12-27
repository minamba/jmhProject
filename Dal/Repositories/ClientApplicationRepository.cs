using OpenIddict.Abstractions;
using OpenIddict.Core;
using Quizz.jmh.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Dal.Repositories
{
    public class ClientApplicationRepository : IClientApplicationRepository
    {
        private readonly IOpenIddictApplicationManager _openIddictApplicationManager;

        //public ClientApplicationRepository(IOpenIddictApplicationManager openIddictApplicationManager)
        //{
        //    _openIddictApplicationManager = openIddictApplicationManager;
        //}

        public async Task CreateApplicationClient()
        {
            var listClient = new List<OpenIddictApplicationDescriptor>()
            {
                new OpenIddictApplicationDescriptor()
                {
                    ClientId = "jmhClient",
                    ClientSecret = "jmh123",
                    DisplayName = "jmh application",
                    Permissions =
                     {
                        OpenIddictConstants.Permissions.Endpoints.Authorization,
                        OpenIddictConstants.Permissions.Endpoints.Logout,
                        OpenIddictConstants.Permissions.Endpoints.Token,
                        OpenIddictConstants.Permissions.GrantTypes.Password,
                        OpenIddictConstants.Permissions.GrantTypes.RefreshToken,
                        OpenIddictConstants.Permissions.Scopes.Email,
                        OpenIddictConstants.Permissions.Scopes.Profile,
                        OpenIddictConstants.Permissions.Scopes.Roles,
                     }

                }
            };
            foreach(var client in listClient)
            {
                var clientExist = _openIddictApplicationManager.FindByClientIdAsync(client.ClientId);

                if (clientExist == null)
                {
                    await _openIddictApplicationManager.CreateAsync(client);
                } 
            }
        }
    }
}