using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.BlogCategoryService
{
    public interface IBlogCategoryService
    {
        Task<IEnumerable<BlogCategory>> GetAllAsync();
        Task AddAsync(BlogCategory entity);
        Task UpdateAsync(BlogCategory entity);
        Task DeleteAsync(BlogCategory entity);
        Task<BlogCategory> GetByIdAsync(int id);
        Task SoftDeleteAsync(int id);
        Task RestoreAsync(int id);
    }
}
