using SPSS.Entities;

namespace SPSS.Service.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product entity);
        Task UpdateAsync(Product entity);
        Task DeleteAsync(Product entity);

    }
}
