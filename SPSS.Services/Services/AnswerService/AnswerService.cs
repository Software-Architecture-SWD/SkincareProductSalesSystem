using Microsoft.Extensions.Logging;
using SPSS.Entities;
using SPSS.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.AnswerService
{
    public class AnswerService(IUnitOfWork _unitOfWork, ILogger<AnswerService> _logger) : IAnswerService
    {
        public async Task<IEnumerable<Answer>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all Answers.");
                return await _unitOfWork.Answers.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all Answers.");
                throw new Exception("An error occurred while retrieving Answers.", ex);
            }
        }
        public async Task<(IEnumerable<Answer> Answers, int TotalCount)> GetPagedAnswersAsync(int page, int pageSize)
        {
            try
            {
                _logger.LogInformation("Fetching all answers for pagination.");

                var allAnswers = await _unitOfWork.Answers.GetAllAsync();
                var totalCount = allAnswers.Count();

                var pagedAnswers = allAnswers.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                _logger.LogInformation("Returning {Count} answers out of {TotalCount} total.", pagedAnswers.Count, totalCount);
                return (pagedAnswers, totalCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching paged answers.");
                throw;
            }
        }
        public async Task AddAsync(Answer p)
        {
            try
            {
                _logger.LogInformation("Adding a new Answer");
                await _unitOfWork.Answers.AddAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding Answer");
                throw;
            }
        }

        public async Task UpdateAsync(Answer p)
        {
            try
            {
                _logger.LogInformation("Updating Answer ID {Id}", p.Id);
                await _unitOfWork.Answers.UpdateAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Answer ID {Id}", p.Id);
                throw;
            }
        }

        public async Task DeleteAsync(Answer p)
        {
            try
            {
                _logger.LogInformation("Deleting Answer ID {Id}", p.Id);
                await _unitOfWork.Answers.DeleteAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting Answer ID {Id}", p.Id);
                throw;
            }
        }
        public async Task SoftDeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Deleting Answer ID {Id}", id);
                await _unitOfWork.Answers.SoftDeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error soft deleting Answer ID {Id}", id);
                throw;
            }
        }

        public async Task RestoreAsync(int id)
        {
            try
            {
                _logger.LogInformation("Restore Answer ID {Id}", id);
                await _unitOfWork.Answers.RestoreAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring Answer ID {Id}", id);
                throw;
            }
        }
        public async Task<int> SumPointsAsync(IEnumerable<int> id)
        {
            try
            {
                _logger.LogInformation("Summing points for answers with IDs {Ids}", string.Join(", ", id));
                return await _unitOfWork.Answers.SumPointsAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error summing points for answers with IDs {Ids}", string.Join(", ", id));
                throw;
            }
        }
    }

}