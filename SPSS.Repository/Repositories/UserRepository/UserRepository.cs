using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SPSS.Entities;

namespace SPSS.Repository.Repositories.User
{
    public class UserRepository(UserManager<AppUser> _userManager) : IUserRepository
    {
        public async Task<AppUser> GetUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
    }
}
