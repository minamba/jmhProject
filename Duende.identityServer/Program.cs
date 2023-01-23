using Duende.IdentityServer.Test;
using Duende.Server.Config;
using Duende.Server.Data;
using Duende.Server.Models;
//using Duende.Server.Models;
using Duende.Server.Test;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quizz.jmh.Domain.DbContext_;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>
    (options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;

    options.EmitStaticAudienceClaim = true; // Audience claim, contient les infos pour le destinataire du token
})/*.AddTestUsers(TestUsers.Users)*/
  .AddInMemoryClients(Config.Clients)
  .AddInMemoryApiResources(Config.ApiResource)
  .AddInMemoryApiScopes(Config.ApiScopes)
  .AddInMemoryIdentityResources(Config.IdentityResources)
  .AddAspNetIdentity<ApplicationUser>()
  .AddDeveloperSigningCredential();

//builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<YourContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

//});


builder.Services.AddCors();

var app = builder.Build();
app.UseCors(config => config
.AllowAnyOrigin()
.AllowAnyHeader()
.AllowAnyMethod());
app.UseIdentityServer();
//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages().RequireAuthorization();
app.Run();