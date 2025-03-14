using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.AnswerDetailService
{
    public interface IAnswerDetailService
    {
        Task<IEnumerable<AnswerDetail>> GetAllAsync();
        Task AddAsync(AnswerDetail entity);
        Task UpdateAsync(AnswerDetail entity);
        Task DeleteAsync(AnswerDetail entity);
        Task<IEnumerable<AnswerDetail>> CreateAnswerDetailsAsync(int answerSheetId, List<int> answerIds);

    }
}
