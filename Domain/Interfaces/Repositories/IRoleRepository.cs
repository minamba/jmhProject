using Quizz.jmh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Domain.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> AddRoleAsync(Role role);
        Task<Role> GetRolesAsync();
        Task<Role> GetRoleByIdAsync(int Id);
        Task<Role> UpdateRoleAsync(Role role);
        Task<Role> DeleteRoleAsync(int id);

    }
}
