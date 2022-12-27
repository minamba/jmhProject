using Microsoft.AspNetCore.Identity;
using Quizz.jmh.Dal.Dto;
using Quizz.jmh.Dal.Extensions;
using Quizz.jmh.Domain.Interfaces.Repositories;
using Quizz.jmh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Dal.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<Role> AddRoleAsync(Role role)
        { 
            RoleDto roleToReturn = new RoleDto();
            IdentityRole newRole = new IdentityRole
            {
                Name = role.Name,
            };

            var roleExist = await _roleManager.RoleExistsAsync(role.Name);

            if (!roleExist)
            {
               IdentityResult succes  =  await _roleManager.CreateAsync(newRole);

                if (succes.Succeeded)
                {
                    roleToReturn.Id = newRole.Id;
                    roleToReturn.Name = newRole.Name;
                }
            }

            return roleToReturn.ToRole();
        }

        public Task<Role> DeleteRoleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetRoleByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Role> UpdateRoleAsync(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
