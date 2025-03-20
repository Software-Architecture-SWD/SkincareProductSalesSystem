using SPSS.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.BlogContentService
{
    public interface IBlogContentService
    {
        Task<IEnumerable<BlogContent>> GetAllAsync();
        Task AddAsync(BlogContent b);
        Task UpdateAsync(BlogContent b);
        Task DeleteAsync(int id);
    }
}
