using Quizz.jmh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Domain.Interfaces.Services
{
    public interface IUserRoleService
    {
        Task<IEnumerable<string>> GetUserRolesAsync(string idUser);
        Task<UserRole> GetUserRoleByIdAsync(int userId);
        Task<UserRole> AddUserRoleAsync(UserRole userRole);
        Task<UserRole> UpdateUserRoleAsync(string idUser, UserRole userRole);
        Task<UserRole> DeleteUserRoleAsync(string idUser);
    }
}
