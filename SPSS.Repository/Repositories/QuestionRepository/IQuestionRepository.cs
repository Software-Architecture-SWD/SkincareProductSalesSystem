using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.QuestionRepository
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAllAsync();
        Task AddAsync(Question q);
        Task UpdateAsync(Question q);
        Task DeleteAsync(Question q);
    }
}
