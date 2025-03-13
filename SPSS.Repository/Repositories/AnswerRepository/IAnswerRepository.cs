using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.AnswerRepository
{
    public interface IAnswerRepository
    {
        Task AddAsync(Answer a);
        Task DeleteAsync(Answer a);
        Task<IEnumerable<Answer>> GetAllAsync();
        Task UpdateAsync(Answer a);
        Task SoftDeleteAsync(int id);
        Task RestoreAsync(int id);
        Task<int> SumPointsAsync(IEnumerable<int> id);

    }
}
