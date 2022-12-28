using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using Duende.Server.Config;
using Duende.Server.Test;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;

    options.EmitStaticAudienceClaim = true; // Audience claim, contient les infos pour le destinataire du token
}).AddTestUsers(TestUsers.Users)
  .AddInMemoryClients(Config.Clients)
  .AddInMemoryApiResources(Config.ApiResource)
  .AddInMemoryApiScopes(Config.ApiScopes)
  .AddInMemoryIdentityResources(Config.IdentityResources);


//builder.Services.AddAuthentication(
//    options =>
//    {
//        options.DefaultScheme = "cookie";
//        options.DefaultChallengeScheme = "oidc";
//    }).AddCookie("cookie")
//    .AddOpenIdConnect("oidc", options =>
//     {
//         options.Authority = builder.Configuration["InteractiveServiceSettings:AuthorityUrl"];
//         options.ClientId = builder.Configuration["InteractiveServiceSettings:ClientId"];
//         options.ClientSecret = builder.Configuration["InteractiveServiceSettings:ClientSecret"];
//         options.Scope.Add(builder.Configuration["InteractiveServiceSettings:Scope:0"]);

//         options.ResponseType = "code";
//         options.UsePkce = true;
//         options.ResponseMode = "query";
//         options.SaveTokens = true;
//     });

var app = builder.Build();
app.UseIdentityServer();
//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages().RequireAuthorization();
app.Run();