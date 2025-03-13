using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.AnswerService
{
    public interface IAnswerService
    {
        Task<IEnumerable<Answer>> GetAllAsync();
        Task<(IEnumerable<Answer> Answers, int TotalCount)> GetPagedAnswersAsync(int page, int pageSize);
        Task AddAsync(Answer entity);
        Task UpdateAsync(Answer entity);
        Task DeleteAsync(Answer entity);
        Task SoftDeleteAsync(int id);
        Task RestoreAsync(int id);
        Task<int> SumPointsAsync(IEnumerable<int> id);

    }
}
