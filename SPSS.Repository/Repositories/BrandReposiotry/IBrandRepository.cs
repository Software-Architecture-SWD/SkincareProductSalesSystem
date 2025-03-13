using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.BrandReposiotry
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllAsync();
        Task<Brand> GetByIdAsync(int id);
        Task<Brand> GetByNameAsync(string name);
        Task AddAsync(Brand b);
        Task UpdateAsync(Brand b);
        Task DeleteAsync(int id);
    }
}
