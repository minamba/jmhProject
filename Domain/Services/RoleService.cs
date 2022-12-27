using Quizz.jmh.Domain.Interfaces.Repositories;
using Quizz.jmh.Domain.Interfaces.Services;
using Quizz.jmh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Domain.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _role_repository;

        public RoleService(IRoleRepository role_repository)
        {
            _role_repository = role_repository;
        }

        public async Task<Role> AddRoleAsync(Role role)
        {
            return await _role_repository.AddRoleAsync(role);
        }

        public async Task<Role> DeleteRoleAsync(int id)
        {
            return await _role_repository.DeleteRoleAsync(id);
        }

        public async Task<Role> GetRoleByIdAsync(int Id)
        {
            return await _role_repository.GetRoleByIdAsync(Id);
        }

        public async Task<Role> GetRolesAsync()
        {
            return await _role_repository.GetRolesAsync();
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            return await _role_repository.UpdateRoleAsync(role);
        }
    }
}
