using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quizz.jmh.Dal.Dto;
using Quizz.jmh.Dal.Extensions;
using Quizz.jmh.Domain.DbContext_;
using Quizz.jmh.Domain.Interfaces.Repositories;
using Quizz.jmh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Dal.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        public Task<UserRole> AddUserRoleAsync(UserRole userRole)
        {
            throw new NotImplementedException();
        }

        public Task<UserRole> DeleteUserRoleAsync(string idUser)
        {
            throw new NotImplementedException();
        }

        public Task<UserRole> GetUserRoleByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetUserRolesAsync(string idUser)
        {
            throw new NotImplementedException();
        }

        public Task<UserRole> UpdateUserRoleAsync(string idUser, UserRole userRole)
        {
            throw new NotImplementedException();
        }
    }
    //{
    //    private readonly UserManager<IdentityUser> _userManager;
    //    private readonly RoleManager<IdentityRole> _roleManager;
    //    //private readonly AppDbContext db = new AppDbContext();
    //    private static readonly jmhContext db2 = new jmhContext();

    //    public UserRoleRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    //    {
    //        _userManager = userManager;
    //        _roleManager = roleManager;
    //    }

    //    public async Task<IEnumerable<string>> GetUserRolesAsync(string idUser)
    //    {
    //        List<string> uroles = new List<string>();

    //        IdentityUser identityUser = await _userManager.FindByIdAsync(idUser);
    //        if (identityUser != null)
    //        {   
    //            var roles = await _userManager.GetRolesAsync(identityUser);

    //            if(roles != null)
    //            {
    //                foreach (var r in roles)
    //                {
    //                    uroles.Add(r);
    //                }
    //                return uroles;
    //            }
    //        }
    //        return null;
    //    }

    //    public async Task<UserRole> GetUserRoleByIdAsync(int userId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public async Task<UserRole> AddUserRoleAsync(UserRole userRole)
    //    {
    //        UserRoleDto userToReturn = new UserRoleDto();
    //        IdentityUser identityUser = await _userManager.FindByIdAsync(userRole.IdUser);
    //        IdentityRole identityRole = await _roleManager.FindByIdAsync(userRole.IdRole);

    //        if (identityUser != null && identityRole != null)
    //        {
    //            var userAlreadyHasARole = await GetUserRolesAsync(identityUser.Id);

    //            if (userAlreadyHasARole.Count() == 0)
    //            {
    //                IdentityResult result = await _userManager.AddToRoleAsync(identityUser, identityRole.Name);

    //                if (result.Succeeded)
    //                {
    //                    var u = await UserToReturn(identityUser);
    //                    return u.ToUserRole();
    //                }
    //            }
    //            else
    //                 throw new Exception("This user already has a rôle");
    //        }
    //        return null;
    //    }

    //    public async Task<UserRole> UpdateUserRoleAsync(string idUser, UserRole userRole)
    //    {
    //        IdentityUser identityUser = await _userManager.FindByIdAsync(idUser);
    //        IdentityRole identityRole = await _roleManager.FindByIdAsync(userRole.IdRole);

    //        var oldRoleName = await GetUserRolesAsync(identityUser.Id);

    //        if (identityUser != null && identityRole != null)
    //        {
    //            IdentityResult result1 = await _userManager.RemoveFromRoleAsync(identityUser, oldRoleName.ElementAt(0));
    //            IdentityResult result2 = await _userManager.AddToRoleAsync(identityUser, identityRole.Name);

    //            if (result1.Succeeded && result2.Succeeded)
    //            {
    //                var u = await UserToReturn(identityUser);
    //                return u.ToUserRole();
    //            }
    //        }
    //        return null;
    //    }

    //    public async Task<UserRole> DeleteUserRoleAsync(string idUser)
    //    {
    //        IdentityUser identityUser = await _userManager.FindByIdAsync(idUser);

    //        var oldRoleName = await GetUserRolesAsync(identityUser.Id);

    //        if (identityUser != null)
    //        {
    //            var u = await UserToReturn(identityUser);
    //            IdentityResult result1 = await _userManager.RemoveFromRoleAsync(identityUser, oldRoleName.ElementAt(0));

    //            if (result1.Succeeded)
    //            {
    //                return u.ToUserRole();
    //            }
    //        }
    //        return null;
    //    }


    //    private async  Task<UserRoleDto> UserToReturn(IdentityUser identityUser)
    //    {
    //        var oldRoleName = await _userManager.GetRolesAsync(identityUser);

    //        UserRoleDto uToReturn = new UserRoleDto()
    //        {
    //            UserName = identityUser.UserName,
    //            RoleName = oldRoleName[0],
    //        };

    //        return uToReturn;
    //    }
    //}
}
