using Quizz.jmh.api.ViewModels;
using Quizz.jmh.Api.Request;
using Quizz.jmh.Domain.Models;

namespace Quizz.jmh.api.Extensions
{
    public static class UserExtensions
    {
        public static IEnumerable<UserViewModel> ToUserViewModel(this IEnumerable<User> users) => users.Select(ToUserViewModel);

        public static UserViewModel ToUserViewModel(this User user) =>
            new()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Pseudonym = user.Pseudonym,
                Sexe = user.Sexe,
                Mail = user.Mail,
                LevelId = user.LevelId,
                Password = user.Password,
            };

        public static User ToUser(this UserPostRequest user)
        {
            return new()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Pseudonym = user.Pseudonym,
                Sexe = user.Sexe,
                Mail = user.Mail,
                LevelId = user.LevelId,
                Password = user.Password,
            };
        }


        public static User ToUser(this UserPutRequest user)
        {
            return new()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Pseudonym = user.Pseudonym,
                Sexe = user.Sexe,
                Mail = user.Mail,
                LevelId = user.LevelId,
            };
        }



    }
}
