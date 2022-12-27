using Microsoft.AspNetCore.Identity;

namespace Duende.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
