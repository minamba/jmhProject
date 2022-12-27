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
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<UserRole> AddUserRoleAsync(UserRole userRole)
        {
            return await _userRoleRepository.AddUserRoleAsync(userRole);
        }

        public async Task<UserRole> DeleteUserRoleAsync(string idUser)
        {
            return await _userRoleRepository.DeleteUserRoleAsync(idUser);   
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(string userId)
        {
            return await _userRoleRepository.GetUserRolesAsync(userId);
        }

        public async Task<UserRole> GetUserRoleByIdAsync(int userId)
        {
            return await _userRoleRepository.GetUserRoleByIdAsync(userId);
        }

        public async Task<UserRole> UpdateUserRoleAsync(string idUser, UserRole userRole)
        {
            return await _userRoleRepository.UpdateUserRoleAsync(idUser, userRole);
        }
    }
}
