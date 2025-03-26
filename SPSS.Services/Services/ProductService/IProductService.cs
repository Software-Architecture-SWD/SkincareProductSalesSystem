using SPSS.Entities;

namespace SPSS.Service.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<(IEnumerable<Product> Products, int TotalCount)> GetPagedProductsAsync(int page, int pageSize);
        Task<(IEnumerable<Product> Products, int TotalCount)> GetFilteredProductsAsync(string? categoryName, string? brandName, string? sortPrice, int page, int pageSize);
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product p);
        Task UpdateAsync(int id, Product updatedProduct);
        Task DeleteAsync(int id);
        Task<Category> GetCategoryByNameAsync(string categoryName);
        Task<Brand> GetBrandByNameAsync(string brandName);

        Task<int> GetTotalProducts();

    }
}
