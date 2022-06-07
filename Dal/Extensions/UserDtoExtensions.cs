using Quizz.jmh.Dal.Dto;
using Quizz.jmh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Dal.Extensions
{
    public static class UserDtoExtensions
    {
        public static IEnumerable<User> ToUser(this IEnumerable<UserDto> users) => users.Select(ToUser);

        public static User ToUser(this UserDto user) =>
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
    }
}
