using Quizz.jmh.Api.Request;
using Quizz.jmh.Api.ViewModels;
using Quizz.jmh.Domain.Models;

namespace Quizz.jmh.Api.Extensions
{
    public static class RoleExtensions
    {
        public static IEnumerable<RoleViewModel> ToRoleViewModel(this IEnumerable<Role> roles) => roles.Select(ToRoleViewModel);

        public static RoleViewModel ToRoleViewModel(this Role role) =>
            new()
            {
                Id = role.Id,
                Name = role.Name,
                
            };


        public static Role ToRole(this RolePostRequest role)
        {
            return new()
            {
                Name = role.Name
            };
        }

    }
}
