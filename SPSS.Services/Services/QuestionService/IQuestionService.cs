using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.QuestionService
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetAllAsync();
        Task<(IEnumerable<Question> Questions, int TotalCount)> GetPagedQuestionsAsync(int page, int pageSize);
        Task AddAsync(Question entity);
        Task UpdateAsync(Question entity);
        Task DeleteAsync(Question entity);
        Task SoftDeleteAsync(int id);
        Task RestoreAsync(int id);
    }
}
