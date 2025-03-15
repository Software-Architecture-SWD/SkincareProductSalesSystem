using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.ResultRepository
{
    public interface IResultRepository
    {
        Task AddAsync(Result result);
        Task DeleteAsync(Result result);
        Task<IEnumerable<Result>> GetAllAsync();
        Task RestoreAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(Result result);
    }
}
