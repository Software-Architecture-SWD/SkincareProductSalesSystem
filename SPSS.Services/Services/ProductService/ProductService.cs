using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SPSS.Entities;
using SPSS.Repository.Repositories.ProductRepository;
using SPSS.Repository.UnitOfWork;
using SPSS.Service.Services.ProductService;

public class ProductService(IUnitOfWork _unitOfWork, ILogger<ProductService> _logger) : IProductService
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        try
        {
            _logger.LogInformation("Fetching all products.");
            return await _unitOfWork.Products.GetAllAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching all products.");
            throw new Exception("An error occurred while retrieving products.", ex);
        }
    }

    public async Task<(IEnumerable<Product> Products, int TotalCount)> GetPagedProductsAsync(int page, int pageSize)
    {
        try
        {
            _logger.LogInformation("Fetching all products for pagination.");

            var allProducts = await _unitOfWork.Products.GetAllAsync();
            var totalCount = allProducts.Count();

            var pagedProducts = allProducts.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            _logger.LogInformation("Returning {Count} products out of {TotalCount} total.", pagedProducts.Count, totalCount);
            return (pagedProducts, totalCount);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching paged products.");
            throw;
        }
    }
    public async Task<(IEnumerable<Product> Products, int TotalCount)> GetFilteredProductsAsync(
    string? categoryName, string? brandName, string? sortPrice, int page, int pageSize)
    {
        try
        {
            _logger.LogInformation("Fetching products with filters: Category={Category}, Brand={Brand}, SortPrice={SortPrice}",
                                   categoryName, brandName, sortPrice);

            var query = _unitOfWork.Products.Query()
                .Include(p => p.Category)
                .Include(p => p.Brand) 
                .AsQueryable(); 

            
            if (!string.IsNullOrEmpty(categoryName))
            {
                query = query.Where(p => p.Category.CategoryName == categoryName);
            }

            
            if (!string.IsNullOrEmpty(brandName))
            {
                query = query.Where(p => p.Brand.BrandName == brandName);
            }

            
            if (!string.IsNullOrEmpty(sortPrice))
            {
                sortPrice = sortPrice.Trim().ToLower(); 

                query = sortPrice == "asc"
                    ? query.OrderBy(p => p.Price).AsQueryable()
                    : query.OrderByDescending(p => p.Price).AsQueryable();
            }

            var totalCount = await query.CountAsync();
            var pagedProducts = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            _logger.LogInformation("Returning {Count} products with filters applied.", pagedProducts.Count);
            return (pagedProducts, totalCount);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching filtered products.");
            throw;
        }
    }


    public async Task<Product> GetByIdAsync(int id)
    {
        try
        {
            _logger.LogInformation("Fetching product with ID {Id}", id);
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
            {
                _logger.LogWarning("Product with ID {Id} not found.", id);
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }

            return product; 
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching product with ID {Id}", id);
            throw;
        }
    }

    public async Task AddAsync(Product p)
    {
        try
        {
            _logger.LogInformation("Adding a new product: {ProductName}", p.ProductName);
            await _unitOfWork.Products.AddAsync(p);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding product: {ProductName}", p.ProductName);
            throw;
        }
    }

    public async Task UpdateAsync(int id, Product p)
    {
        try
        {
            _logger.LogInformation("Updating product ID {Id}", p.Id);
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                _logger.LogWarning("Product with ID {Id} not found.", id);
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }
            await _unitOfWork.Products.UpdateAsync(p);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating product ID {Id}", p.Id);
            throw;
        }
    }

    public async Task<Category> GetCategoryByNameAsync(string categoryName)
    {
        try
        {
            var category = await _unitOfWork.Products.GetCategoryByNameAsync(categoryName);
            if (category == null)
            {
                _logger.LogWarning("Category not found: {CategoryName}", categoryName);
            }
            return category;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting category by name: {CategoryName}", categoryName);
            throw new Exception("An error occurred while retrieving the category.");
        }
    }

    public async Task<Brand> GetBrandByNameAsync(string brandName)
    {
        try
        {
            var brand = await _unitOfWork.Products.GetBrandByNameAsync(brandName);
            if (brand == null)
            {
                _logger.LogWarning("Brand not found: {BrandName}", brandName);
            }
            return brand;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting brand by name: {BrandName}", brandName);
            throw new Exception("An error occurred while retrieving the brand.");
        }
    }


    public async Task DeleteAsync(int id)
    {
        try
        {
            _logger.LogInformation("Deleting product ID {Id}", id);
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if(product == null)
            {
                _logger.LogWarning("Product with ID {Id} not found.", id);
                throw new KeyNotFoundException($"Product with ID {id} not found.");

            }
            else await _unitOfWork.Products.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting product ID {Id}", id);
            throw;
        }
    }

    public async Task<int> GetTotalProducts()
    {
        try
        {
            return await _unitOfWork.Products.GetTotalProducts();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching total products");
            return 0;
        }
    }

}
