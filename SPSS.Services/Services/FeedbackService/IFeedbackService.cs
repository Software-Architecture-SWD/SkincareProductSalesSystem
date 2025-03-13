using SPSS.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.FeedbackService
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Feedback>> GetAllAsync();
        Task<Feedback> GetByIdAsync(int id);
        Task<IEnumerable<Feedback>> GetFeedbacksByProductIdAsync(int productId);
        Task<(IEnumerable<Feedback> Feedbacks, int TotalCount)> GetPagedFeedbacksByProductIdAsync(int productId, int page, int pageSize);
        Task AddAsync(Feedback entity);
        Task UpdateAsync(Feedback entity);
        Task DeleteAsync(int id);

        Task RestoreAsync(int id);

    }
}