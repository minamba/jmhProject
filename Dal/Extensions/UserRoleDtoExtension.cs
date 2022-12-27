using Quizz.jmh.Dal.Dto;
using Quizz.jmh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Dal.Extensions
{
    public static class UserRoleDtoExtension
    {
        public static IEnumerable<UserRole> ToUserRole(this IEnumerable<UserRoleDto> userRoles) => userRoles.Select(ToUserRole);

        public static UserRole ToUserRole(this UserRoleDto urdto) =>
            new()
            {
                 IdRole = urdto.IdRole,
                 IdUser = urdto.IdUser,
                 UserName = urdto.UserName,
                 RoleName = urdto.RoleName,
            };
    }
}
