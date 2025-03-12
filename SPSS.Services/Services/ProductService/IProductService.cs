using Microsoft.AspNetCore.Http;
using SPSS.Dto.Request;
using SPSS.Dto.Response;
using SPSS.Entities;

namespace SPSS.Service.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<(IEnumerable<Product> Products, int TotalCount)> GetPagedProductsAsync(int page, int pageSize);
        Task<(IEnumerable<Product> Products, int TotalCount)> GetFilteredProductsAsync(string? categoryName, string? brandName, string? sortPrice, int page, int pageSize);
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product entity);
        Task UpdateAsync(Product entity);
        Task DeleteAsync(Product entity);
        Task<Product> CreateProductAsync(ProductRequest productRequest);
    }
}
