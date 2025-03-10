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
}

