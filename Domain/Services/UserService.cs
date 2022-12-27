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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User> ReplaceAllUserFieldsAsync(string id)
        {
            return await _userRepository.ReplaceAllUserFieldsAsync(id);
        }

        public async Task<User> UpdateUserAsync(string id, User user)
        {
            return await _userRepository.UpdateUserAsync(id, user);
        }

        public async Task<User> DeleteUserAsync(string id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        public async Task<User> GetUserByIdUserAsync(string id)
        {
            return await _userRepository.GetUserByIdUserAsync(id);
        }

        public async Task<User> AddUserAsync(User user)
        {
            return await _userRepository.AddUserAsync(user);
        }
    }
}
