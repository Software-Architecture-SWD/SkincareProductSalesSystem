using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.SkinTypeRepository
{
   public interface ISkinTypeRepository
    {
        Task AddAsync(SkinType s);
        Task DeleteAsync(SkinType s);
        Task<IEnumerable<SkinType>> GetAllAsync();
        Task UpdateAsync(SkinType s);
        Task SoftDeleteAsync(int id);
        Task RestoreAsync(int id);
        Task<SkinType> GetByIdAsync(int id);
        Task<SkinType> GetByNameAsync(string name);

    }
}
