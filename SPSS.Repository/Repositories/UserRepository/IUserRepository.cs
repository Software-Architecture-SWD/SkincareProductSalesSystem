using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPSS.Entities;

namespace SPSS.Repository.Repositories.User
{
    public interface IUserRepository
    {
        Task<AppUser> GetUserById(string id);
    }
}
