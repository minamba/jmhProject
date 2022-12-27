
using Quizz.jmh.Api.Request;
using Quizz.jmh.Api.ViewModels;
using Quizz.jmh.Domain.Models;

namespace Quizz.jmh.Api.Extensions
{
    public static class UserRoleExtensions
    {
        public static IEnumerable<UserRoleViewModel> ToUserRoleViewModel(this IEnumerable<UserRole> userRoles) => userRoles.Select(ToUserRoleViewModel);

           public static UserRoleViewModel ToUserRoleViewModel(this UserRole ur) =>         
            new ()
            {
               UserName = ur.UserName,
               RoleName = ur.RoleName,
            };

        public static UserRole ToUserRole(this UserRolePostRequest userRole)
        {
            return new()
            {
                IdUser = userRole.UserId,
                IdRole = userRole.RoleId
            };
        }


        public static UserRole ToUserRole(this UserRolePutRequest userRole)
        {
            return new()
            {
                IdRole = userRole.RoleId
            };
        }


    }
}