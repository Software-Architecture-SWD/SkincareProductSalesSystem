using SPSS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.PromotionRepository
{
    public interface IPromotionRepository
    {
        Task<IEnumerable<Promotion>> GetAllAsync();
        Task<Promotion> GetByIdAsync(int id);
        Task AddAsync(Promotion p);
        Task UpdateAsync(Promotion p);
        Task DeleteAsync(Promotion p);
        IQueryable<Promotion> Query();
    }
}
