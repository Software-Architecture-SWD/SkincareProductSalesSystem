using SPSS.Entities;
using SPSS.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Repository.Repositories.FeedbackRepository
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetAllAsync();
        Task<IEnumerable<Feedback>> GetByProductIdAsync(int productId);
        Task<Feedback> GetByIdAsync(int id);
        Task AddAsync(Feedback f);
        Task UpdateAsync(Feedback f);
        Task DeleteAsync(int id);
    }
}