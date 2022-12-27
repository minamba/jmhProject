using Quizz.jmh.Api.Responses;
using Quizz.jmh.Api.ViewModels;
using Swashbuckle.AspNetCore.Filters;

namespace Quizz.jmh.Api.SwaggerExamples
{
    public class UserRoleResponseExample : IExamplesProvider<UserRoleResponse>
    {
        public UserRoleResponse GetExamples() => new UserRoleResponse
        {
             //new string
             //   {
             //       IdRole = "5DF35719B67E4FF78F617A27D3312233090",
             //       IdUser = "5DF35719B67E4FF78F617A27D3359A34"
             //   }             
        };

    }
}
