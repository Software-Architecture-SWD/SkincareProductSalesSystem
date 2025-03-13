using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product p);
        Task UpdateAsync(Product p);
        Task DeleteAsync(int id);
        Task<Brand> GetBrandByNameAsync(string brandName);
        Task<Category> GetCategoryByNameAsync(string categoryName);

    }
}
