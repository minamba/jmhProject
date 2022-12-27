using Quizz.jmh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdUserAsync(string id);
        Task<User> ReplaceAllUserFieldsAsync(string id);
        Task<User> UpdateUserAsync(string id, User user);
        Task<User> DeleteUserAsync(string id);
        Task<User> AddUserAsync(User user);

    }
}
