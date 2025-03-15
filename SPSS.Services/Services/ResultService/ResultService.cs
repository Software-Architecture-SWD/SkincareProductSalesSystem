using Microsoft.Extensions.Logging;
using SPSS.Entities;
using SPSS.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.ResultService
{
    public class ResultService(IUnitOfWork _unitOfWork, ILogger<ResultService> _logger): IResultService
    {
        public async Task<IEnumerable<Result>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all Results.");
                return await _unitOfWork.Results.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all Results.");
                throw new Exception("An error occurred while retrieving Results.", ex);
            }
        }
        public async Task AddAsync(Result p)
        {
            try
            {
                _logger.LogInformation("Adding a new Result");
                await _unitOfWork.Results.AddAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding Result");
                throw;
            }
        }
        public async Task UpdateAsync(Result p)
        {
            try
            {
                _logger.LogInformation("Updating Result");
                await _unitOfWork.Results.UpdateAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Result");
                throw;
            }
        }
        public async Task DeleteAsync(Result p)
        {
            try
            {
                _logger.LogInformation("Deleting Result");
                await _unitOfWork.Results.DeleteAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting Result");
                throw;
            }
        }
        public async Task SoftDeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Soft deleting Result");
                await _unitOfWork.Results.SoftDeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error soft deleting Result");
                throw;
            }
        }
        public async Task RestoreAsync(int id)
        {
            try
            {
                _logger.LogInformation("Restoring Result");
                await _unitOfWork.Results.RestoreAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring Result");
                throw;
            }
        }
        public async Task<string> GetSkinTypeNameByPointAsync(int point)
{
    try
    {
        _logger.LogInformation($"Fetching SkinType for point: {point}");

                var results = await _unitOfWork.Results.GetAllAsync();
                var result = results.FirstOrDefault(r => r.MinPoint <= point && r.MaxPoint >= point && !r.isDelete);

        if (result == null || result.SkinType == null)
        {
            _logger.LogWarning($"No matching SkinType found for point: {point}");
            return "Unknown";
        }

        return result.SkinType.Name;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error fetching SkinType by point.");
        throw;
    }
}

    }
}
