using OpenIddict.Abstractions;
using Quizz.jmh.Domain.DbContext_;
using Quizz.jmh.Domain.Migrations;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace OpeniddictServer.HostedService
{
    public class Worker : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public Worker(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await context.Database.EnsureCreatedAsync(cancellationToken);

            var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();

            if (await manager.FindByClientIdAsync("jmhClient", cancellationToken) is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "jmhClient",
                    ClientSecret = "901564A5-E7FE-42CB-B10D-61EF6A8F3654",
                    DisplayName = "jmh client",
                    Permissions =
                {
                    Permissions.Endpoints.Token,
                    Permissions.GrantTypes.ClientCredentials,
                    Permissions.Endpoints.Authorization,
                    //Permissions.GrantTypes.AuthorizationCode,
                    OpenIddictConstants.Permissions.Prefixes.Scope + "api"
                }
                }, cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
