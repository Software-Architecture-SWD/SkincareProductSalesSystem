using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.CategoryRepositoty
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(Category c);
        Task UpdateAsync(Category c);
        Task DeleteAsync(Category c);
        IQueryable<Category> Query();
    }
}
