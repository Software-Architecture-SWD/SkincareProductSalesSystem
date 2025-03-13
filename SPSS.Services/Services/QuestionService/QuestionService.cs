using Microsoft.Extensions.Logging;
using SPSS.Entities;
using SPSS.Repository.UnitOfWork;
using SPSS.Service.Services.QuestionService;


public class QuestionService(IUnitOfWork _unitOfWork, ILogger<QuestionService> _logger) : IQuestionService
{
    public async Task<IEnumerable<Question>> GetAllAsync()
    {
        try
        {
            _logger.LogInformation("Fetching all questions.");
            return await _unitOfWork.Questions.GetAllAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching all questions.");
            throw new Exception("An error occurred while retrieving questions.", ex);
        }
    }

    public async Task<(IEnumerable<Question> Questions, int TotalCount)> GetPagedQuestionsAsync(int page, int pageSize)
    {
        try
        {
            _logger.LogInformation("Fetching all Questions for pagination.");

            var allQuestions = await _unitOfWork.Questions.GetAllAsync();
            var totalCount = allQuestions.Count();

            var pagedQuestions = allQuestions.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            _logger.LogInformation("Returning {Count} Questions out of {TotalCount} total.", pagedQuestions.Count, totalCount);
            return (pagedQuestions, totalCount);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching paged Questions.");
            throw;
        }
    }

    public async Task AddAsync(Question p)
    {
        try
        {
            _logger.LogInformation("Adding a new question");
            await _unitOfWork.Questions.AddAsync(p);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding question");
            throw;
        }
    }

    public async Task UpdateAsync(Question p)
    {
        try
        {
            _logger.LogInformation("Updating question ID {Id}", p.Id);
            await _unitOfWork.Questions.UpdateAsync(p);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating question ID {Id}", p.Id);
            throw;
        }
    }

    public async Task DeleteAsync(Question p)
    {
        try
        {
            _logger.LogInformation("Deleting question ID {Id}", p.Id);
            await _unitOfWork.Questions.DeleteAsync(p);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting question ID {Id}", p.Id);
            throw;
        }
    }
    public async Task SoftDeleteAsync(int id)
    {
        try
        {
            _logger.LogInformation("Deleting Question ID {Id}", id);
            await _unitOfWork.Questions.SoftDeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error soft deleting Question ID {Id}", id);
            throw;
        }
    }

    public async Task RestoreAsync(int id)
    {
        try
        {
            _logger.LogInformation("Restore Question ID {Id}", id);
            await _unitOfWork.Questions.RestoreAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error restoring Question ID {Id}", id);
            throw;
        }
    }
}

