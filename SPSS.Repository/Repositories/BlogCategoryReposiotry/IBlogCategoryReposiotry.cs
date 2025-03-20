using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.BlogCategoryReposiotry
{
    public interface IBlogCategoryReposiotry
    {
        Task AddAsync(BlogCategory a);
        Task DeleteAsync(BlogCategory a);
        Task<IEnumerable<BlogCategory>> GetAllAsync();
        Task UpdateAsync(BlogCategory a);
        Task<BlogCategory> GetByIdAsync(int id);
        Task SoftDeleteAsync(int id);
        Task RestoreAsync(int id);
    }
}
