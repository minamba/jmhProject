using Quizz.jmh.api.ViewModels;
using Quizz.jmh.Api.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace Quizz.jmh.Api.SwaggerExamples
{
    public class UsersResponseExample : IExamplesProvider<UsersResponse>
    {

        public UsersResponse GetExamples() => new UsersResponse
        {
            Users = new[]
             {
                new UserViewModel
                {
                  Id = "aze123aze",
                  FirstName = "Jean",
                  LastName = "Delarue", 
                  Pseudonym = "jd",
                  Mail = "jd@gmail.com",
                  Sexe = "Homme",
                  LevelId = "eza321eza",
                  Password =  "xxxxxxx"                   
                },
                new UserViewModel
                {
                  Id = "nbv123vbn",
                  FirstName = "Pierre",
                  LastName = "Dupont",
                  Pseudonym = "pierrot",
                  Mail = "pierre.d@gmail.com",
                  Sexe = "Homme",
                  LevelId = "nvb321vbn",
                  Password =  "xxxxxxx"
                }
            }
        };
    }
}
