using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.AnswerSheetService
{
    public interface IAnswerSheetService
    {
        Task<IEnumerable<AnswerSheet>> GetAllAsync();
        Task<(IEnumerable<AnswerSheet> AnswerSheets, int TotalCount)> GetPagedAnswerSheetsAsync(int page, int pageSize);
        Task AddAsync(AnswerSheet entity);
        Task UpdateAsync(AnswerSheet entity);
        Task DeleteAsync(AnswerSheet entity);
        Task SoftDeleteAsync(int id);
        Task RestoreAsync(int id);
    }
}
