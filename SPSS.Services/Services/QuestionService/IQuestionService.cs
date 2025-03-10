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
        Task AddAsync(Question entity);
        Task UpdateAsync(Question entity);
        Task DeleteAsync(Question entity);
    }
}
