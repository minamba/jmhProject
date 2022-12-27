using Quizz.jmh.Api.Responses;
using Quizz.jmh.Api.ViewModels;
using Swashbuckle.AspNetCore.Filters;

namespace Quizz.jmh.Api.SwaggerExamples
{
    public class UserRolesResponseExample : IExamplesProvider<UserRolesResponse>
    {
        public UserRolesResponse GetExamples() => new UserRolesResponse
        {
            UserRoles = new List<string>()
              {
                "User",
                "Admin",
              }
        };
     }
}
