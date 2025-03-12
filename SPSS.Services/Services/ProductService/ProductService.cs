using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    public async Task UpdateAsync(Product p)
    {
        try
        {
            _logger.LogInformation("Updating product ID {Id}", p.Id);
            await _unitOfWork.Products.UpdateAsync(p);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating product ID {Id}", p.Id);
            throw;
        }
    }

    public async Task DeleteAsync(Product p)
    {
        try
        {
            _logger.LogInformation("Deleting product ID {Id}", p.Id);
            await _unitOfWork.Products.DeleteAsync(p);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting product ID {Id}", p.Id);
            throw;
        }
    }
}
