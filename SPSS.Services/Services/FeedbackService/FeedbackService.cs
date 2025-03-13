using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SPSS.Entities;
using SPSS.Repository.Entities;
using SPSS.Repository.UnitOfWork;
using SPSS.Service.Services.FeedbackService;

public class FeedbackService(IUnitOfWork _unitOfWork, ILogger<FeedbackService> _logger) : IFeedbackService
{
    public async Task<IEnumerable<Feedback>> GetAllAsync()
    {
        try
        {
            _logger.LogInformation("Fetching all feedbacks.");
            return await _unitOfWork.Feedbacks.GetAllAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching all feedbacks.");
            throw new Exception("An error occurred while retrieving feedbacks.", ex);
        }
    }

    public async Task<Feedback> GetByIdAsync(int id)
    {
        try
        {
            _logger.LogInformation("Fetching feedback with ID {Id}", id);
            var feedback = await _unitOfWork.Feedbacks.GetByIdAsync(id);

            if (feedback == null)
            {
                _logger.LogWarning("Feedback with ID {Id} not found.", id);
                throw new KeyNotFoundException($"Feedback with ID {id} not found.");
            }

            return feedback;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching feedback with ID {Id}", id);
            throw;
        }
    }

    public async Task<IEnumerable<Feedback>> GetFeedbacksByProductIdAsync(int productId)
    {
        try
        {
            _logger.LogInformation("Fetching feedbacks for product ID {ProductId}", productId);
            return await _unitOfWork.Feedbacks.GetByProductIdAsync(productId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching feedbacks for product ID {ProductId}", productId);
            throw new Exception("An error occurred while retrieving feedbacks.", ex);
        }
    }

    public async Task AddAsync(Feedback f)
    {
        try
        {
            _logger.LogInformation("Adding a new feedback");
            await _unitOfWork.Feedbacks.AddAsync(f);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding feedback");
            throw;
        }
    }

    public async Task UpdateAsync(Feedback f)
    {
        try
        {
            _logger.LogInformation("Updating feedback ID {Id}", f.Id);
            await _unitOfWork.Feedbacks.UpdateAsync(f);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating feedback ID {Id}", f.Id);
            throw;
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            _logger.LogInformation("Marking feedback ID {Id} as deleted", id);
            var feedback = await _unitOfWork.Feedbacks.GetByIdAsync(id);
            if (feedback == null) 
            {
                _logger.LogWarning("Feedback with ID not found", id);
                throw new KeyNotFoundException();
            }
            else await _unitOfWork.Feedbacks.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting feedback ID {Id}", id);
            throw;
        }
    }
    public async Task RestoreAsync(int id)
    {
        try
        {
            _logger.LogInformation("Restoring feedback ID {Id}", id);
            var feedback = await _unitOfWork.Feedbacks.GetByIdAsync(id);

            if (feedback == null)
            {
                _logger.LogWarning("Feedback with ID {Id} not found.", id);
                throw new KeyNotFoundException($"Feedback with ID {id} not found.");
            }

            feedback.isDelete = false;
            await _unitOfWork.Feedbacks.UpdateAsync(feedback);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error restoring feedback ID {Id}", id);
            throw;
        }
    }

    public async Task<(IEnumerable<Feedback> Feedbacks, int TotalCount)> GetPagedFeedbacksByProductIdAsync(int productId, int page, int pageSize)
    {
        try
        {
            _logger.LogInformation("Fetching all feedbacks for product ID {ProductId} with pagination.", productId);

           
            var allFeedbacks = await _unitOfWork.Feedbacks.GetAllAsync();
            var filteredFeedbacks = allFeedbacks.Where(f => f.ProductId == productId && !f.isDelete);
            var totalCount = filteredFeedbacks.Count();

            
            var pagedFeedbacks = filteredFeedbacks.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            _logger.LogInformation("Returning {Count} feedbacks out of {TotalCount} total.", pagedFeedbacks.Count, totalCount);
            return (pagedFeedbacks, totalCount);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching paged feedbacks for product ID {ProductId}", productId);
            throw;
        }
    }


}