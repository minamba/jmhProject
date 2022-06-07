using Quizz.jmh.api.ViewModels;
using Quizz.jmh.Api.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace Quizz.jmh.Api.SwaggerExamples
{
    public class UserResponseExample : IExamplesProvider<UserResponse>
    {
        public UserResponse GetExamples() => new UserResponse
        {
            User = new UserViewModel
            {
                Id = "aze123aze",
                FirstName = "Jean",
                LastName = "Delarue",
                Pseudonym = "jd",
                Mail = "jd@gmail.com",
                Sexe = "Homme",
                LevelId = "eza321eza",
                Password = "xxxxxxx"
            }

        };
    }
}
