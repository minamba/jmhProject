using Quizz.jmh.Dal.Dto;
using Quizz.jmh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Dal.Extensions
{
    public static class RoleDtoExtensions
    {
        public static IEnumerable<Role> ToRole(this IEnumerable<RoleDto> roles) => roles.Select(ToRole);

        public static Role ToRole(this RoleDto role) =>
            new()
            {
                 Id = role.Id,
                 Name = role.Name,
            };
    }
}
