using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.AnswerSheetRepository
{
    public interface IAnswerSheetRepository
    {
        Task AddAsync(AnswerSheet a);
        Task DeleteAsync(AnswerSheet a);
        Task<IEnumerable<AnswerSheet>> GetAllAsync();
        Task UpdateAsync(AnswerSheet a);
        Task SoftDeleteAsync(int id);
        Task RestoreAsync(int id);
    }
}
