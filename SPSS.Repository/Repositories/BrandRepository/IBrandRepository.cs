using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.BrandRepository
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllAsync();
        Task AddAsync(Brand b);
        Task UpdateAsync(Brand b);
        Task DeleteAsync(Brand b);
        Task<Brand?> FindByNameAsync(string brandName);
    }
}
