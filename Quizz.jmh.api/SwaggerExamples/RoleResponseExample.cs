using Quizz.jmh.Api.Responses;
using Quizz.jmh.Api.ViewModels;
using Swashbuckle.AspNetCore.Filters;

namespace Quizz.jmh.Api.SwaggerExamples
{
    public class RoleResponseExample : IExamplesProvider<RoleResponse>
    {
        public RoleResponse GetExamples() => new RoleResponse
        {
            Role = new RoleViewModel
                {
                  Id = "azzaz1a2za",
                  Name = "Admin"
                }
            
        };

    }
}
