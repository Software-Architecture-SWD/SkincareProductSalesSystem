using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.BrandService
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetAllAsync();
        Task<Brand> GetByIdAsync(int id);
        Task<Brand> GetByNameAsync(string name);
        Task AddAsync(Brand b);
        Task UpdateAsync(int id, Brand b);
        Task DeleteAsync(int id);
    }
}
