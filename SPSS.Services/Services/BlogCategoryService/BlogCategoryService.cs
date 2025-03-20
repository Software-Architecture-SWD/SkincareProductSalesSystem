using Microsoft.Extensions.Logging;
using SPSS.Entities;
using SPSS.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.BlogCategoryService
{
    public class BlogCategoryService(IUnitOfWork _unitOfWork, ILogger<BlogCategoryService> _logger) : IBlogCategoryService
    {
        public async Task<IEnumerable<BlogCategory>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all BlogCategories.");
                return await _unitOfWork.BlogCategories.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all BlogCategories.");
                throw new Exception("An error occurred while retrieving BlogCategories.", ex);
            }
        }
        public async Task AddAsync(BlogCategory p)
        {
            try
            {
                _logger.LogInformation("Adding a new BlogCategory");
                await _unitOfWork.BlogCategories.AddAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding BlogCategory");
                throw;
            }
        }
        public async Task<BlogCategory> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Fetching BlogCategory by id");
                return await _unitOfWork.BlogCategories.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching BlogCategory by id");
                throw;
            }
        }
        public async Task UpdateAsync(BlogCategory p)
        {
            try
            {
                _logger.LogInformation("Updating BlogCategory");
                await _unitOfWork.BlogCategories.UpdateAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating BlogCategory");
                throw;
            }
        }
        public async Task DeleteAsync(BlogCategory p)
        {
            try
            {
                _logger.LogInformation("Deleting BlogCategory");
                await _unitOfWork.BlogCategories.DeleteAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting BlogCategory");
                throw;
            }
        }
        public async Task SoftDeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Deleting BlogCategory");
                await _unitOfWork.BlogCategories.SoftDeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error soft deleting BlogCategory");
                throw;
            }
        }
        public async Task RestoreAsync(int id)
        {
            try
            {
                _logger.LogInformation("Restoring BlogCategory");
                await _unitOfWork.BlogCategories.RestoreAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring BlogCategory");
                throw;
            }
        }
    }
}
