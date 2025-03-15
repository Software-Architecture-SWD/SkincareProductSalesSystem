using Microsoft.Extensions.Logging;
using SPSS.Entities;
using SPSS.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPSS.Service.Services.AnswerDetailService;
using SPSS.Service.Services.AnswerService;
using SPSS.Service.Services.ResultService;

namespace SPSS.Service.Services.AnswerSheetService
{
    public class AnswerSheetService(IUnitOfWork _unitOfWork, ILogger<AnswerSheetService> _logger, IAnswerDetailService _answerDetailService, IAnswerService _answerService, IResultService _resultService) : IAnswerSheetService
    {
        public async Task<IEnumerable<AnswerSheet>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all AnswerSheets.");
                return await _unitOfWork.AnswerSheets.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all AnswerSheets.");
                throw new Exception("An error occurred while retrieving AnswerSheets.", ex);
            }
        }
        public async Task<(IEnumerable<AnswerSheet> AnswerSheets, int TotalCount)> GetPagedAnswerSheetsAsync(int page, int pageSize)
        {
            try
            {
                _logger.LogInformation("Fetching all AnswerSheets for pagination.");
                var allAnswerSheets = await _unitOfWork.AnswerSheets.GetAllAsync();
                var totalCount = allAnswerSheets.Count();
                var pagedAnswerSheets = allAnswerSheets.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                _logger.LogInformation("Returning {Count} AnswerSheets out of {TotalCount} total.", pagedAnswerSheets.Count, totalCount);
                return (pagedAnswerSheets, totalCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching paged AnswerSheets.");
                throw;
            }
        }
        public async Task AddAsync(AnswerSheet p)
        {
            try
            {
                _logger.LogInformation("Adding a new AnswerSheet");
                await _unitOfWork.AnswerSheets.AddAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding AnswerSheet");
                throw;
            }
        }
        public async Task UpdateAsync(AnswerSheet p)
        {
            try
            {
                _logger.LogInformation("Updating AnswerSheet");
                await _unitOfWork.AnswerSheets.UpdateAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating AnswerSheet");
                throw;
            }
        }
        public async Task DeleteAsync(AnswerSheet p)
        {
            try
            {
                _logger.LogInformation("Deleting AnswerSheet");
                await _unitOfWork.AnswerSheets.DeleteAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting AnswerSheet");
                throw;
            }
        }
        public async Task SoftDeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Soft deleting AnswerSheet");
                await _unitOfWork.AnswerSheets.SoftDeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error soft deleting AnswerSheet");
                throw;
            }
        }
        public async Task RestoreAsync(int id)
        {
            try
            {
                _logger.LogInformation("Restoring AnswerSheet");
                await _unitOfWork.AnswerSheets.RestoreAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring AnswerSheet");
                throw;
            }
        }
        public async Task<(string skintype, int totalPoints)> SubmitAnswerSheetsAsync(int answerSheetId, List<int> answerIds)
        {
            try
            {
                _logger.LogInformation("Submit AnswerSheets");
                var createdDetails = await _answerDetailService.CreateAnswerDetailsAsync(answerSheetId, answerIds);

                var answerSheet = await _unitOfWork.AnswerSheets.GetByIdAsync(answerSheetId);
                if (answerSheet == null)
                {
                    _logger.LogInformation("AnswerSheet with ID {AnswerSheetId} not found.", answerSheetId);
                    throw new Exception($"AnswerSheet with ID {answerSheetId} not found.");
                }
                var totalPoints = await _answerService.SumPointsAsync(answerIds);
                answerSheet.TotalPoint = totalPoints;
                await _unitOfWork.AnswerSheets.UpdateAsync(answerSheet);
                var skintype = await _resultService.GetSkinTypeNameByPointAsync(totalPoints);
                return (skintype, totalPoints);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error submitting AnswerSheets");
                throw;
            }
        }
    }
}
