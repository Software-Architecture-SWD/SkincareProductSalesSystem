using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.BlogService
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetAllAsync();
        Task<(IEnumerable<Blog> Blogs, int TotalCount)> GetPagedBlogsAsync(int page, int pageSize);
        Task AddAsync(Blog entity);
        Task UpdateAsync(Blog entity);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task RestoreAsync(int id);
        Task<Blog?> GetByIdAsync(int id);
    }
}
