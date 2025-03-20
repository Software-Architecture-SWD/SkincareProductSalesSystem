using Microsoft.Extensions.Logging;
using SPSS.Repository.Entities;
using SPSS.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.BlogContentService
{
    public class BlogContentService(IUnitOfWork _unitOfWork, ILogger<BlogContentService> _logger) : IBlogContentService
    {
        public async Task<IEnumerable<BlogContent>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all blog contents.");
                return await _unitOfWork.BlogContents.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all blog contents.");
                throw new Exception("An error occurred while retrieving blog contents.", ex);
            }
        }
        public async Task AddAsync(BlogContent b)
        {
            try
            {
                _logger.LogInformation("Adding a new blog content");
                await _unitOfWork.BlogContents.AddAsync(b);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding blog content");
                throw;
            }
        }
        public async Task UpdateAsync(BlogContent b)
        {
            try
            {
                _logger.LogInformation("Updating blog content");
                await _unitOfWork.BlogContents.UpdateAsync(b);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating blog content");
                throw;
            }
        }
        public async Task DeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Deleting blog content");
                await _unitOfWork.BlogContents.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting blog content");
                throw;
            }
        }
    }
}
