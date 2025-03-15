using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.SkinTypeService
{
    public interface ISkinTypeService
    {
        Task<IEnumerable<SkinType>> GetAllAsync();
        Task<(IEnumerable<SkinType> SkinTypes, int TotalCount)> GetPagedSkinTypesAsync(int page, int pageSize);
        Task AddAsync(SkinType entity);
        Task UpdateAsync(SkinType entity);
        Task DeleteAsync(SkinType entity);
        Task SoftDeleteAsync(int id);
        Task RestoreAsync(int id);
        Task<SkinType> GetByIdAsync(int id);
        Task<SkinType> GetByNameAsync(string name);
    }
}
