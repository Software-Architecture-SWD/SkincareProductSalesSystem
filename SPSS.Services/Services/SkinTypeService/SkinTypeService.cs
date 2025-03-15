using Microsoft.Extensions.Logging;
using SPSS.Entities;
using SPSS.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.SkinTypeService
{
    public class SkinTypeService(IUnitOfWork _unitOfWork, ILogger<SkinTypeService> _logger) : ISkinTypeService
    {
        public async Task<IEnumerable<SkinType>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all SkinTypes.");
                return await _unitOfWork.SkinTypes.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all SkinTypes.");
                throw new Exception("An error occurred while retrieving SkinTypes.", ex);
            }
        }
        public async Task<(IEnumerable<SkinType> SkinTypes, int TotalCount)> GetPagedSkinTypesAsync(int page, int pageSize)
        {
            try
            {
                _logger.LogInformation("Fetching all SkinTypes for pagination.");
                var allSkinTypes = await _unitOfWork.SkinTypes.GetAllAsync();
                var totalCount = allSkinTypes.Count();
                var pagedSkinTypes = allSkinTypes.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                _logger.LogInformation("Returning {Count} SkinTypes out of {TotalCount} total.", pagedSkinTypes.Count, totalCount);
                return (pagedSkinTypes, totalCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching paged SkinTypes.");
                throw;
            }
        }
        public async Task AddAsync(SkinType p)
        {
            try
            {
                _logger.LogInformation("Adding a new SkinType");
                await _unitOfWork.SkinTypes.AddAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding SkinType");
                throw;
            }
        }
        public async Task UpdateAsync(SkinType p)
        {
            try
            {
                _logger.LogInformation("Updating SkinType");
                await _unitOfWork.SkinTypes.UpdateAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating SkinType");
                throw;
            }
        }
        public async Task DeleteAsync(SkinType p)
        {
            try
            {
                _logger.LogInformation("Deleting SkinType");
                await _unitOfWork.SkinTypes.DeleteAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting SkinType");
                throw;
            }
        }
        public async Task SoftDeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Soft deleting SkinType");
                await _unitOfWork.SkinTypes.SoftDeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error soft deleting SkinType");
                throw;
            }
        }
        public async Task RestoreAsync(int id)
        {
            try
            {
                _logger.LogInformation("Restoring SkinType");
                await _unitOfWork.SkinTypes.RestoreAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring SkinType");
                throw;
            }
        }
        public async Task<SkinType> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Fetching SkinType by Id");
                return await _unitOfWork.SkinTypes.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching SkinType by Id");
                throw;
            }
        }
        public async Task<SkinType> GetByNameAsync(string name)
        {
            try
            {
                _logger.LogInformation("Fetching SkinType by Name");
                return await _unitOfWork.SkinTypes.GetByNameAsync(name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching SkinType by Name");
                throw;
            }
        }
    }
}
