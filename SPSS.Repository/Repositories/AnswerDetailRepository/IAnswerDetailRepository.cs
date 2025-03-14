using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.AnswerDetailRepository
{
    public interface IAnswerDetailRepository
    {
        Task AddAsync(AnswerDetail a);
        Task AddRangeAsync(List<AnswerDetail> answerDetails);
        Task DeleteAsync(AnswerDetail a);
        Task<IEnumerable<AnswerDetail>> GetAllAsync();
        Task UpdateAsync(AnswerDetail a);
    }
}
