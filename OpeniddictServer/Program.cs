using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpeniddictServer.HostedService;
using Quizz.jmh.Domain.DbContext_;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    // Configure the context to use Microsoft SQL Server.
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseOpenIddict();
});


builder.Services.AddIdentityCore<IdentityUser>
    (options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddRoles<IdentityRole>()
    .AddDefaultTokenProviders();


builder.Services.AddOpenIddict()

       // Register the OpenIddict core components.
       .AddCore(options =>
       {
            // Configure OpenIddict to use the Entity Framework Core stores and models.
            // Note: call ReplaceDefaultEntities() to replace the default entities.
            options.UseEntityFrameworkCore()
                  .UseDbContext<AppDbContext>();
           
       })


       // Register the OpenIddict server components.
       .AddServer(options =>
       {
           options.IgnoreEndpointPermissions();

           // Enable the token endpoint.
           options.SetTokenEndpointUris("/connect/token");

           options.SetAuthorizationEndpointUris("/connect/authorize");

            // Enable the client credentials flow.
           options.AllowClientCredentialsFlow();

            // Register the signing and encryption credentials.
            //options.AddDevelopmentEncryptionCertificate()
            //      .AddDevelopmentSigningCertificate();

           options
           .AddEphemeralEncryptionKey()
           .AddEphemeralSigningKey();

           // Register scopes (permissions)
           options.RegisterScopes("jmhAPI");
           options.AcceptAnonymousClients();
           // Register the ASP.NET Core host and configure the ASP.NET Core options.
           options.UseAspNetCore()
                  .EnableTokenEndpointPassthrough();
       })

       // Register the OpenIddict validation components.
       .AddValidation(options =>
       {
            // Import the configuration from the local OpenIddict server instance.
            options.UseLocalServer();

            // Register the ASP.NET Core host.
            options.UseAspNetCore();
       });


builder.Services.AddHostedService<Worker>();

var app = builder.Build();
app.UseHttpsRedirection();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(options =>
{
    options.MapDefaultControllerRoute();
});

app.Run();
