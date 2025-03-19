using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SPSS.Entities;
using SPSS.Repository.UnitOfWork;
using SPSS.Service.Services.PromotionService;

public class PromotionService(IUnitOfWork _unitOfWork, ILogger<PromotionService> _logger) : IPromotionService
{

    public async Task<IEnumerable<Promotion>> GetAllAsync()
    {
        try
        {
            _logger.LogInformation("Fetching all promotions.");
            return await _unitOfWork.Promotions.GetAllAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching all promotions.");
            throw new Exception("An error occurred while retrieving promotions.", ex);
        }
    }

    public async Task<Promotion> GetByIdAsync(int id)
    {
        try
        {
            _logger.LogInformation("Fetching promotion with ID {Id}", id);
            var promotion = await _unitOfWork.Promotions.GetByIdAsync(id);

            if (promotion == null)
            {
                _logger.LogWarning("Promotion with ID {Id} not found.", id);
                throw new KeyNotFoundException($"Promotion with ID {id} not found.");
            }

            return promotion;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching promotion with ID {Id}", id);
            throw;
        }
    }

    public async Task AddAsync(Promotion entity)
    {
        try
        {
            _logger.LogInformation("Adding a new promotion.");
            await _unitOfWork.Promotions.AddAsync(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding promotion.");
            throw;
        }
    }

    public async Task UpdateAsync(Promotion entity)
    {
        try
        {
            _logger.LogInformation("Updating promotion ID {Id}", entity.Id);
            await _unitOfWork.Promotions.UpdateAsync(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating promotion ID {Id}", entity.Id);
            throw;
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            _logger.LogInformation("Marking promotion ID {Id} as deleted.", id);
            var promotion = await _unitOfWork.Promotions.GetByIdAsync(id);
            if (promotion == null)
            {
                _logger.LogWarning("Promotion with ID {Id} not found.", id);
                throw new KeyNotFoundException($"Promotion with ID {id} not found.");
            }

            // Xóa mềm bằng cách đánh dấu isDelete = true
            promotion.isDelete = true;
            await _unitOfWork.Promotions.UpdateAsync(promotion);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting promotion ID {Id}.", id);
            throw;
        }
    }

    public async Task RestoreAsync(int id)
    {
        try
        {
            _logger.LogInformation("Restoring promotion ID {Id}.", id);
            var promotion = await _unitOfWork.Promotions.GetByIdAsync(id);

            if (promotion == null)
            {
                _logger.LogWarning("Promotion with ID {Id} not found.", id);
                throw new KeyNotFoundException($"Promotion with ID {id} not found.");
            }

            promotion.isDelete = false;
            await _unitOfWork.Promotions.UpdateAsync(promotion);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error restoring promotion ID {Id}.", id);
            throw;
        }
    }

    public async Task<(IEnumerable<Promotion> Promotions, int TotalCount)> GetPagedPromotionsAsync(int page, int pageSize)
    {
        try
        {
            _logger.LogInformation("Fetching promotions with pagination.");
            var allPromotions = await _unitOfWork.Promotions.GetAllAsync();
            var activePromotions = allPromotions.Where(p => !p.isDelete);  
            var totalCount = activePromotions.Count();

            var pagedPromotions = activePromotions.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            _logger.LogInformation("Returning {Count} promotions out of {TotalCount} total.", pagedPromotions.Count, totalCount);
            return (pagedPromotions, totalCount);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching paged promotions.");
            throw;
        }
    }
    public async Task ApplyPromotionAsync(string categoryName, string promotionCode)
    {
        try
        {
           
            var category = await _unitOfWork.Categories.Query()
                .Where(c => c.CategoryName.ToLower() == categoryName.ToLower() && !c.isDelete)
                .FirstOrDefaultAsync();

            if (category == null)
            {
                _logger.LogWarning("Category with name {CategoryName} not found.", categoryName);
                throw new KeyNotFoundException($"Category with name {categoryName} not found.");
            }

            var promotion = await _unitOfWork.Promotions.Query()
                .Where(p => p.Code.ToLower() == promotionCode.ToLower() && !p.isDelete)
                .FirstOrDefaultAsync();

            if (promotion == null)
            {
                _logger.LogWarning("Promotion with code {PromotionCode} not found.", promotionCode);
                throw new KeyNotFoundException($"Promotion with code {promotionCode} not found.");
            }

            if (promotion.EndDate < DateTime.UtcNow)
            {
                _logger.LogWarning("Promotion with code {PromotionCode} has expired.", promotionCode);
                throw new InvalidOperationException($"Promotion with code {promotionCode} has expired.");
            }

            var productsInCategory = await _unitOfWork.Products.Query()
                .Where(p => p.CategoryId == category.Id)
                .ToListAsync();

            foreach (var product in productsInCategory)
            {
                product.PromotionId = promotion.Id;

                await _unitOfWork.Products.UpdateAsync(product); 
            }

            await _unitOfWork.CompleteAsync();

            _logger.LogInformation("Promotion with code {PromotionCode} applied to all products in category {CategoryName}.", promotionCode, categoryName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error applying promotion to category.");
            throw;
        }
    }

    public async Task ApplyPromotionOrderAsync(int orderId, string promotionCode)
    {
        try
        {

            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);

            if (order == null)
            {
                _logger.LogWarning("Order with ID {OrderId} not found.", orderId);
                throw new KeyNotFoundException($"Order with ID {orderId} not found.");
            }

            var promotion = await _unitOfWork.Promotions.Query()
                .Where(p => p.Code.ToLower() == promotionCode.ToLower() && !p.isDelete)
                .FirstOrDefaultAsync();

            if (promotion == null)
            {
                _logger.LogWarning("Promotion with code {PromotionCode} not found.", promotionCode);
                throw new KeyNotFoundException($"Promotion with code {promotionCode} not found.");
            }

            if (promotion.EndDate < DateTime.UtcNow)
            {
                _logger.LogWarning("Promotion with code {PromotionCode} has expired.", promotionCode);
                throw new InvalidOperationException($"Promotion with code {promotionCode} has expired.");
            }

            order.PromotionId = promotion.Id;
            await _unitOfWork.Orders.UpdateOrderAsync(order);
            await _unitOfWork.CompleteAsync();

            _logger.LogInformation("Promotion with code {PromotionCode} applied to order {OrderId}.", promotionCode, orderId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error applying promotion to category.");
            throw;
        }
    }

    public async Task RemovePromotionAsync(string categoryName)
    {
        try
        {
            var category = await _unitOfWork.Categories.Query()
                .Where(c => c.CategoryName.ToLower() == categoryName.ToLower() && !c.isDelete)
                .FirstOrDefaultAsync();

            if (category == null)
            {
                _logger.LogWarning("Category with name {CategoryName} not found.", categoryName);
                throw new KeyNotFoundException($"Category with name {categoryName} not found.");
            }

            var productsInCategory = await _unitOfWork.Products.Query()
                .Where(p => p.CategoryId == category.Id && p.PromotionId != null)
                .ToListAsync();

            foreach (var product in productsInCategory)
            {
                var promotion = await _unitOfWork.Promotions.GetByIdAsync(product.PromotionId.Value);

                decimal originalPrice = product.Price / (1 - promotion.DiscountValue / 100);

                product.Price = originalPrice;

                product.PromotionId = null;

                await _unitOfWork.Products.UpdateAsync(product); 
            }

            await _unitOfWork.CompleteAsync();

            _logger.LogInformation("Promotion removed from all products in category {CategoryName}.", categoryName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error removing promotion from category.");
            throw;
        }
    }

}
