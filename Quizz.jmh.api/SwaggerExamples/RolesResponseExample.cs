using Quizz.jmh.api.ViewModels;
using Quizz.jmh.Api.Responses;
using Quizz.jmh.Api.ViewModels;
using Swashbuckle.AspNetCore.Filters;

namespace Quizz.jmh.Api.SwaggerExamples
{
    public class RolesResponseExample : IExamplesProvider<RolesResponse>
    {
        public RolesResponse GetExamples() => new RolesResponse
        {
            Roles = new[]
            {
                new RoleViewModel
                {
                  Id = "123abc123",
                  Name = "Admin"
                },
                new RoleViewModel
                {
                    Id="124abc124",
                    Name = "User"
                }
            }
        };
    }
}




