using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.ResultService
{
    public interface IResultService
    {
        Task<IEnumerable<Result>> GetAllAsync();
        Task AddAsync(Result entity);
        Task UpdateAsync(Result entity);
        Task DeleteAsync(Result entity);
        Task SoftDeleteAsync(int id);
        Task RestoreAsync(int id);
        Task<string> GetSkinTypeNameByPointAsync(int point);
    }
}
